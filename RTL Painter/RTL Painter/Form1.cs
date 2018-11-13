using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RTL_Painter
{
    //basic methods for Form1, methods for toolbar are separated (in 'Classes' folder)
    public partial class Form1 : Form
    {
        private ShapeList shapeList;
        private Shape selected;
        private Shape current;
        private Point prev;
        private Color penColor;
        private int width;
        string selectedTool;

        public Form1()
        {
            InitializeComponent();
            shapeList = new ShapeList();
            DoubleBuffered = true;
            penColor = Color.Blue;
            BackColor = Color.White;
            shapeList.bckgColor = BackColor;
            width = 4;

            toolLine.ToolTipText = "Draw line";
            toolCircle.ToolTipText = "Draw circle";
            toolTriangle.ToolTipText = "Draw triangle";
            toolStar.ToolTipText = "Draw star";
            toolPenColor.ToolTipText = "Pen color";
            toolBackgroundColor.ToolTipText = "Background color";
            toolStepBack.ToolTipText = "Step back";
            toolClear.ToolTipText = "Clear all";
            toolOpen.ToolTipText = "Open scene";
            toolSave.ToolTipText = "Save scene";
            toolExit.ToolTipText = "Exit";

            Paint += (s, e) =>
            {
                shapeList.Draw(e.Graphics);
            };
        }

        private void PaintChoise(MouseEventArgs e)
        {
            try
            {
                switch (selectedTool)
                {
                    case "toolLine":
                        current = new Line();
                        break;
                    case "toolCircle":
                        current = new Circle();
                        break;
                    case "toolTriangle":
                        current = new Triangle();
                        break;
                    case "toolStar":
                        current = new Star();
                        break;
                    default:
                        break;
                }
                current.start = current.end = e.Location;
                current.penColor = penColor;
                current.penWidth = width;
                shapeList.Add(current);
            } catch (Exception ex) { }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected == null)
            {
                if (current != null)
                {
                    current.end = e.Location;
                    Invalidate();
                }
                return;
            }

            PointF shift = Point.Subtract(e.Location, new Size(prev));
            prev = e.Location;
            selected.loc = PointF.Add(selected.loc, new SizeF(shift));
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            current = null;
            selected = null;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            selected = shapeList.FindShape(e.X, e.Y);
            prev = e.Location;
            if (selected is null)
            {
                PaintChoise(e);
                Invalidate();
            }
        }

    }
}
