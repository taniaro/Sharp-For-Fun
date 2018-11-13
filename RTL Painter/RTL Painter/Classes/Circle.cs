using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RTL_Painter
{
    [Serializable]
    public class Circle : Shape
    {
        public override GraphicsPath grPath
        {
            get
            {
                var path = new GraphicsPath();
                path.AddEllipse(start.X, start.Y, end.X - start.X, end.Y - start.Y);
                return path;
            }
        }
    }
}
