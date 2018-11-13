using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    public class Sampler
    {
        public float[] x;
        public float[] y;
        public int size;
        public int sf; //sampling frequency
        public float step, max;

        public Sampler(int amp, int f, int sf, float max)
        {
            this.sf = sf;
            this.max = max;
            step = Convert.ToSingle(1.0 / (sf)); 
            size = Convert.ToInt32(max / step);
            x = new float[size];
            y = new float[size];
        }

        public void Sampling()
        {
            float j = 0;
            for(int i=0; i<size; i++, j += step)
            {
                x[i] = j;
                y[i] = BasicFunction.Func(j);
            }
        }
    }
}
