using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RTL_Painter
{
    public abstract class Shape
    {
        //початкові і кінцеві координати
        public PointF start { get; set; }
        public PointF end { get; set; }

        public virtual GraphicsPath grPath { get; }

        public int penWidth { get; set; }
        public Color penColor { get; set; }

        // розташування
        public PointF loc
        {
            get { return start; }
            set
            {
                PointF shift = PointF.Subtract(value, new SizeF(loc));
                start = value;
                end = PointF.Add(end, new SizeF(shift));
            }
        }

        public static PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }
    }
}
