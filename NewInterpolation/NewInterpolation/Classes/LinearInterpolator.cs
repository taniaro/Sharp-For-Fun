using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    public class LinearInterpolator : Interpolator
    {
        public float[] x;
        public float[] y;
        public float[] resX;
        public float[] resY;
        public int size, freq;
        public float max,min, step;

        public void setup(float[] x, float[] y, int freq, int sf, float max)
        {
            int N = x.Length;
            this.x = new float[N];
            this.y = new float[N];

            for (int i = 0; i < N; i++)
            {
                this.x[i] = x[i];
                this.y[i] = y[i];
            }
            this.freq = freq;
            step = Convert.ToSingle(1.0 / (freq));
            size = Convert.ToInt32(max / step);

            resX = new float[size];
            resY = new float[size];

            float j = 0;
            for (int i = 0; i < size; i++, j += step)
                resX[i] = j;

            this.max = max + step * 2;
            min = x[0] - step * 2;

        }

        public float interpolate(float x)
        {
            int i = Convert.ToInt32((x - min) / step);
            //double m1 = (second.x - first.x) / (second.t - first.t);
            //i.x = first.x + (m1 * (i.t - first.t));
            float xp = resX[i+1]- resX[i] / y[i+1] - y[i];          
            float res = y[i] + xp * (x - resX[i]);
            return res;
        }

        public void interpolation()
        {
            for (int i = 0; i < size-4; i++)
                resY[i] = interpolate(resX[i]);
        }
    }
}
