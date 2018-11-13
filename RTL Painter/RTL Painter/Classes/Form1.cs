using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RTL_Painter
{
    //there are methods from Form1 for toolbar 
    public partial class Form1 : Form
    {
        private void ButtonChecker(object sender)
        {
            foreach (ToolStripButton btn in toolStrip1.Items)
            {
                btn.Checked = false;
            }

            ToolStripButton btnClicked = sender as ToolStripButton;
            btnClicked.Checked = true;
            selectedTool = btnClicked.Name;
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            ButtonChecker(sender);
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {
            ButtonChecker(sender);
        }

        private void toolTriangle_Click(object sender, EventArgs e)
        {
            ButtonChecker(sender);
        }

        private void toolStar_Click(object sender, EventArgs e)
        {
            ButtonChecker(sender);
        }

        private void toolPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog1.Color;
            }
        }

        private void toolBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
                shapeList.bckgColor = BackColor;
            }
        }

        private void toolStepBack_Click(object sender, EventArgs e)
        {
            try
            {
                int lastindex = shapeList.Count - 1;
                shapeList.RemoveAt(lastindex);
            }
            catch (Exception ex) { }
            Invalidate();
        }

        private void toolClear_Click(object sender, EventArgs e)
        {
            shapeList.Clear();
            Invalidate();
        }

        private void textBoxLineWidth_TextChanged(object sender, EventArgs e)
        {
            bool t = Int32.TryParse(textBoxLineWidth.Text, out width);
            if (!t || (width > 1000 || width < 0)) width = 2;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.DefaultExt = "dat";
            sfd.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, shapeList);
                    fs.Close();
                }
            }
        }

        private void toolOpen_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.DefaultExt = "dat";
            ofd.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate))
                {
                    shapeList.Clear();
                    shapeList = (ShapeList)formatter.Deserialize(fs);
                    fs.Close();
                }
            }

            BackColor = shapeList.bckgColor;
            Paint += (s, a) =>
            {
                shapeList.Draw(a.Graphics);
            };
            Invalidate();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
