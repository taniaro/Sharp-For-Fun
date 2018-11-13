using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RTL_Painter
{
    [Serializable]
    public class Star : Shape
    {
        public override GraphicsPath grPath
        {
            get
            {
                var path = new GraphicsPath();
                Rectangle r = new Rectangle(
                    (int)start.X, (int)start.Y,
                    (int)end.X - (int)start.X,
                    (int)end.Y - (int)start.Y);
                PointF[] pts = StarPoints(5, r);
                path.AddPolygon(pts);
                return path;
            }
        }
    }
}
