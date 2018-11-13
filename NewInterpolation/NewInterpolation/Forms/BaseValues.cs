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
    public partial class BaseValues : Form
    {
        public BaseValues()
        {
            InitializeComponent();
        }

        private void form2_buttonOk_Click(object sender, EventArgs e)
        {
            //якщо не вдалось зчитати значення, то встановлюються за замовчуванням
            bool b1 = Int32.TryParse(box1.Text, out MainForm.Amp);
            if (b1 != true) MainForm.Amp = 25;
            if (MainForm.Amp >= 1000) MainForm.Amp = 25;
            bool b2 = Int32.TryParse(box2.Text, out MainForm.freq);
            if (b2 != true) MainForm.freq = 440;
            if (MainForm.freq >= 10000) MainForm.freq = 440;
            this.Close();
        }
    }
}
