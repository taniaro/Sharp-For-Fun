using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    public class BsplineInterpolator : Interpolator
    {
        public float[] x;
        public float[] y;
        public float[] resX;
        public float[] resY;
        public int size, freq;
        public float min, max, step;
        public void setup(float[] x, float[] y, int freq, int sf, float max)
        {
            int N = x.Length + 4;
            this.x = new float[N];
            this.y = new float[N];
            
            for (int i = 0; i < N-4; i++)
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

            this.min = x[0] - step * 2;
            this.max = max + step * 2;

        }

        public float interpolate(float x)
        {
            int i = Convert.ToInt32((x - min) / step);
            float xp = x - resX[i];

            float ym1py1 = y[i+1] + y[i + 3];
            float c0 = 1 / 6.0f * ym1py1 + 2 / 3.0f * y[i+2];
            float c1 = 1 / 2.0f * (y[i + 3] - y[i+1]);
            float c2 = 1 / 2.0f * ym1py1 - y[i+2];
            float c3 = 1 / 2.0f * (y[i+2] - y[i + 3]) + 1 / 6.0f * (y[i + 4] - y[i+1]);

            float res = ((c3 * xp + c2) * xp + c1) * xp + c0;

            return res;
        }

        public void interpolation()
        {
            for(int i=0; i<size-3; i++)
                resY[i] = interpolate(resX[i]);
        }
    }
}
