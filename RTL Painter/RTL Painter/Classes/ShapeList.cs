using System;
using System.Collections.Generic;
using System.Drawing;

namespace RTL_Painter
{
    [Serializable]
    public class ShapeList : List<Shape>
    {
        public Color bckgColor{ get; set; }

        public ShapeList() { }

        public void Draw(Graphics g)
        {
            Pen pen;
            foreach (var i in this)
            {
                pen = new Pen(i.penColor, i.penWidth);
                g.DrawPath(pen, i.grPath);
            }
        }

        public Shape FindShape(float x, float y)
        {
            Pen pen;
            foreach(var i in this)
            {
                var path = i.grPath;
                pen = new Pen(i.penColor, i.penWidth);
                if(path.IsVisible(x,y) || path.IsOutlineVisible(x,y,pen))
                    return i;
            }

            return null;
        }
    }
}
