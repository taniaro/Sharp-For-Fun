using System;
using System.Windows.Forms;

namespace NewInterpolation
{
    public enum mode
    {
        linear,
        bspline,
        other
    }
    public partial class MainForm : Form
    {
        public BasicFunction bf;
        public Sampler sm;
        public LinearInterpolator ln;
        public BsplineInterpolator bs;
        public static int Amp, freq, sampling_f, linterp_f, binterp_f, scrollvalue;
        public float time;
        public mode ourmode;
        public MainForm()
        {
            InitializeComponent();
            label2.Text = "";
            label4.Text = "";
            label6.Text = "";
            trackBar2.Enabled = false;
            trackBar2.Visible = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:##0.###}u";
        }

        private void setup()
        {
            ourmode = mode.other;
            BaseValues bv = new BaseValues();
            bv.ShowDialog();

            time = BasicFunction.calcSize(freq);
            float step = BasicFunction.calcStep(freq);
            bf = new BasicFunction(Amp, freq, time, step);
            bf.BuildBasicFunction();

            label2.Text = BasicFunction.Amp.ToString();
            label4.Text = BasicFunction.f.ToString();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int i=0; i<bf.size; i++)
                chart1.Series[0].Points.AddXY(bf.xTable[i], bf.yTable[i]);

            trackBar2.Visible = false;
            trackBar2.Enabled = false;

        }

        private void sample()
        {
            if (freq == 0 || Amp == 0)
            {
                ErrorMessadge em = new ErrorMessadge();
                em.ShowDialog();
            }
            else
            {
                ourmode = mode.other;
                SamplingValues sv = new SamplingValues();
                sv.setlabelandvalues("Частота дискретизації: ", MainForm.freq * 5, MainForm.freq * 100);
                sv.ShowDialog();
                sampling_f = sv.sampling_freq;
                label6.Text = sampling_f.ToString();
                sm = new Sampler(Amp, freq, sampling_f, time);
                sm.Sampling();

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                for (int i = 0; i < sm.size; i++)
                    chart1.Series[0].Points.AddXY(sm.x[i], sm.y[i]);
                trackBar2.Visible = false;
                trackBar2.Enabled = false;
            }
        }

        private void linear()
        {
            if (sampling_f == 0)
            {
                ErrorMessadge em = new ErrorMessadge();
                em.ShowDialog();
            }
            else
            {
                SamplingValues sv = new SamplingValues();
                sv.setlabelandvalues("Частота передискретизації: ", sampling_f * 2, sampling_f * 20);
                sv.ShowDialog();
                linterp_f = sv.sampling_freq;

                ourmode = mode.linear;
                ln = new LinearInterpolator();
                ln.setup(sm.x, sm.y, sampling_f, sampling_f, time);
                ln.interpolation();
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                for (int i = 0; i < ln.size - 4; i++)
                    chart1.Series[0].Points.AddXY(ln.resX[i] + ln.step * 2, ln.resY[i]);
                for (int i = 0; i < sm.size - 4; i++)
                    chart1.Series[1].Points.AddXY(sm.x[i], sm.y[i]);

                trackBar2.Visible = true;
                trackBar2.Enabled = true;
            }

        }

        private void bspline()
        {
            if (sampling_f == 0)
            {
                ErrorMessadge em = new ErrorMessadge();
                em.ShowDialog();
            }
            else
            {
                SamplingValues sv = new SamplingValues();
                sv.setlabelandvalues("Частота передискретизації: ", sampling_f * 2, sampling_f * 20);
                sv.ShowDialog();
                binterp_f = sv.sampling_freq;

                ourmode = mode.bspline;
                bs = new BsplineInterpolator();
                bs.setup(sm.x, sm.y, sampling_f, sampling_f, time);
                bs.interpolation();
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                for (int i = 0; i < bs.size - 7; i++)
                    chart1.Series[0].Points.AddXY(bs.resX[i] + bs.step * 5, bs.resY[i]);
                for (int i = 0; i < sm.size - 4; i++)
                    chart1.Series[1].Points.AddXY(sm.x[i], sm.y[i]);

                trackBar2.Visible = true;
                trackBar2.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sample();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            linear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bspline();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 50;
            chart1.Series[0].Points.Clear();

            if (ourmode == mode.bspline)
            {
                for (int i = 0; i < bs.size - 4; i++)
                    chart1.Series[0].Points.AddXY(bs.resX[i] + bs.step * 5, bs.resY[i] + trackBar2.Value);
            }
            else if (ourmode == mode.linear)
            {
                for (int i = 0; i < ln.size-4; i++)
                chart1.Series[0].Points.AddXY(ln.resX[i] + ln.step*3, ln.resY[i] + trackBar2.Value);
            }
        }
    }
}
