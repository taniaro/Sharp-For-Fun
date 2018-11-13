using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewRunningString
{
    public partial class Form1 : Form
    {
        Matrix m;
        string text = "";
        int speed;
        public Form1()
        {
            m = new Matrix(170, 55);
            this.Controls.Add(m.panel);
            speed = 250;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = speed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m.runSentence();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m.writeSentence(textBox1.Text);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Red);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Yellow);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Lime);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Cyan);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Magenta);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            m.changeColor(Color.Blue);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 10;
            trackBar1.Maximum = 1000;
            speed = trackBar1.Value;
            label4.Text = trackBar1.Value.ToString();
        }
    }
}
