using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

namespace WorkWithUsart
{
    public partial class Form1 : Form
    {
        DateTime dateTime;
        public Form1()
        {
            InitializeComponent();
            InitPortList();
        }

        void InitPortList()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string p in ports)
                comboBox1.Items.Add(p);
        }

        //setting date and time
        private void button1_Click(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();
            string time = dateTime.ToLongTimeString();
            string[] d_arr = date.Split('/');
            string[] t_arr = time.Split(':');

            string timetosend = "*t " + t_arr[0] + " "
                + t_arr[1] + " " + t_arr[2] + "#";
            int year = Int32.Parse(d_arr[2]);
            int month = Int32.Parse(d_arr[0]);
            month--;
            string ms = month.ToString();
            year += 2000;
            if (ms.Length < 2) ms = "0" + ms;
            if (d_arr[1].Length < 2) d_arr[1] = "0" + d_arr[1];
            string datetosend = "*d " + d_arr[1] + " "
                + ms + " " + year.ToString() + "#";

            if (comboBox1.Text != "")
            {
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                }
                serialPort1.BaudRate = 9600;
                serialPort1.WriteLine(timetosend);
                serialPort1.WriteLine(datetosend);
                label2.Text = "Done!";
                serialPort1.Close();
            }
        }

        //updates port names
        private void button5_Click(object sender, EventArgs e)
        {
            InitPortList();
        }

        //setting work and blink period
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(serialPort1, comboBox1.Text);
            form2.Show();
        }

        //getting work and blink period values
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                }
                serialPort1.BaudRate = 9600;
                string mstr1 = Read("*y#");
                string mstr2 = Read("*z#");
                mstr1 = mstr1.Remove(0, 1);
                mstr1 = mstr1.Insert(2, " :");
                mstr2 = mstr2.Remove(0, 1);
                mstr2 = mstr2.Insert(2, " :");
                string text = String.Format("Work period: {0}, blink period: {1}", mstr1, mstr2);
                MessageBox.Show(text, "Work/blink information");

            }
        }

        string Read(string start)
        {
            serialPort1.WriteLine(start);
            string mstr = "";
            try
            {
                int sz = 0;
                int[] arr = new int[6];
                char[] arr1 = new char[6];
                while (sz < 6)
                {
                    arr[sz] = serialPort1.ReadByte();
                    arr1[sz] = (char)arr[sz];
                    sz++;
                }
                mstr = new string(arr1);
            }
            catch (TimeoutException) { }

            return mstr;
        }

        //exit
        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
