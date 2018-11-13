using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RTL_Painter
{
    [Serializable]
    public class Triangle : Shape
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
                PointF[] pts = StarPoints(3, r);
                path.AddPolygon(pts);
                return path;
            }
        }

        //public static PointF[] StarPoints(int num_points, Rectangle bounds)
        //{
        //    PointF[] pts = new PointF[num_points];

        //    double rx = bounds.Width / 2;
        //    double ry = bounds.Height / 2;
        //    double cx = bounds.X + rx;
        //    double cy = bounds.Y + ry;

        //    double theta = -Math.PI / 2;
        //    double dtheta = 4 * Math.PI / num_points;
        //    for (int i = 0; i < num_points; i++)
        //    {
        //        pts[i] = new PointF(
        //            (float)(cx + rx * Math.Cos(theta)),
        //            (float)(cy + ry * Math.Sin(theta)));
        //        theta += dtheta;
        //    }

        //    return pts;
        //}
    }
}
