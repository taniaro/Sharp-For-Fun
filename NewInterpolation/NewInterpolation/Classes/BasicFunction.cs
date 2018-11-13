using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    public class BasicFunction
    {
        public float[] xTable;
        public float[] yTable;
        public float step, max;
        public int size;
        public static int Amp;
        public static int f;

        public BasicFunction(int amp, int fr, float max, float step)
        {
            Amp = amp;
            f = fr;
            this.step = step;
            this.max = max;

            size = Convert.ToInt32(max / step) + 1;
            xTable = new float[size];
            yTable = new float[size];
            
        }

        public void BuildBasicFunction()
        {
            float j = 0;
            for(int i=0; i<size; i++, j += step)
            {
                xTable[i] = j;
                yTable[i] = Func(j);
            }
        }

        public static float Func(float x)
        {
            var y = Amp * Math.Sin(2 * Math.PI * f * x);
            return (float)y;
        }

        public static float calcSize(int freq)
        {
            float s = 0;
            s = (freq >= 25) ? ((freq >= 100)?  (freq >= 1000 ? (freq >= 10000 ? 0.0001f : 0.001f) : 0.01f): 0.1f) : 1;  
            return s;
        }

        public static float calcStep(int freq)
        {
            return 0.1f / freq;
        }
    }
}
