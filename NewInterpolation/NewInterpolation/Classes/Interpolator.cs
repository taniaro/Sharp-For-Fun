using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    interface Interpolator
    {
        void setup(float[] x, float[] y, int freq, int sf, float max);
        float interpolate(float value);
        void interpolation();
    }
}
