using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewInterpolation
{
    public partial class SamplingValues : Form
    {
        public int sampling_freq;
        public int s;
        public SamplingValues()
        {
            InitializeComponent();
            sampling_freq = 0;
        }

        public void setlabelandvalues(string n, int min, int max)
        {
            label1.Text = n;
            trackBar1.Minimum = min;
            trackBar1.Maximum = max;
        }

        public void form2_buttonOk_Click(object sender, EventArgs e)
        {
            string tmp = label2.Text;
            bool p = Int32.TryParse(tmp, out sampling_freq);
            if (p == false) sampling_freq = MainForm.freq * 10;
            Close();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            trackBar1.TickFrequency = 10000;
            label2.Text = trackBar1.Value.ToString();
        }
    }
}
