using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace WorkWithUsart
{
    public partial class Form2 : Form
    {
        SerialPort port;
        string name;
        List<TextBox> tb;
        int[] data;
        string[] sdata;
        bool b;

        public Form2(SerialPort port, string name)
        {
            InitializeComponent();
            this.port = port;
            this.name = name;
            data = new int[4];
            sdata = new string[4];
            tb = new List<TextBox>();
            tb.Add(textBoxw1);
            tb.Add(textBoxw2);
            tb.Add(textBoxb1);
            tb.Add(textBoxb2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                b = Int32.TryParse(tb[i].Text, out data[i]);
                if (b == false) data[i] = 0;
                sdata[i] = data[i].ToString();
                if (sdata[i].Length < 2)
                    sdata[i] = "0" + sdata[i];
            }

            string s1 = "*w " + sdata[0] + " " + sdata[1] + "#";
            string s2 = "*b " + sdata[2] + " " + sdata[3] + "#";

            if(port.IsOpen == false)
            {
                port.PortName = name;
                port.Open();
            }
            port.BaudRate = 9600;
            port.WriteLine(s1);
            port.WriteLine(s2);
            port.Close();

            this.Close();
        }
    }
}
