using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RTL_Painter
{
    [Serializable]
    public class Line : Shape
    {
        public override GraphicsPath grPath
        {
            get
            {
                var path = new GraphicsPath();
                path.AddLine(start, end);
                return path;
            }
        }
    }
}
