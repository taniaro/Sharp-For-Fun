using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewRunningString
{
    class Matrix
    {
        String[] sentence;
        PictureBox[,] disp = new PictureBox[8, 64];
        char[,] ecran = new char[8, 64];
        public Panel panel = new Panel();
        int count;
        private int width = 1000;
        private int height = 125;
        private int diodesize = 14;
        Color color;

        public Matrix(int pw, int ph)
        {
            panel.Size = new Size(width, height);
            panel.Location = new Point(pw, ph);
            color = Color.Red;
            int startw, starth = 1;
            for (int i = 0; i < 8; i++)
            {
                startw = 1;
                if (i > 0) starth += 15;
                for (int j = 0; j < 64; j++, startw += 15)
                {
                    disp[i, j] = new PictureBox();
                    disp[i, j].Size = new Size(diodesize, diodesize);
                    disp[i, j].Location = new Point(startw, starth);
                    disp[i, j].BackColor = Color.Black;
                    panel.Controls.Add(disp[i, j]);
                }
            }
            panel.Visible = true;

        }

        public void changeColor(Color color)
        {
            this.color = color;
        }

        public static string ToBinary(int digits, string hex)
        {
            UInt64 n = UInt64.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            string bin = "";
            UInt64 f;
            string tmp = "";

            while (n != 0)
            {
                f = n % 2;
                tmp = f.ToString();
                bin = tmp + bin;
                n /= 2;
            }

            if (bin.Length < digits)
            {
                int zeros = digits - bin.Length;
                for (int i = 0; i < zeros; i++)
                    bin = bin.Insert(i, "0");
            }
            return bin;
        }

        public void writeSentence(string text)
        {
            text = "        " + text;
            count = text.Length;
            sentence = new String[8];

            char[] arr = text.ToCharArray();
            for (int i = 0; i < count; i++)
                LoadLetter(arr[i]);

            for(int i=0; i<8; i++)
            {
                var tmp = sentence[i].ToCharArray();
                for (int j=0; j<64; j++)
                {
                    ecran[i, j] = tmp[j];
                }
            }

        }

        public void runSentence()
        {
            for(int i=0; i<8; i++)
            {
                var first = sentence[i].ElementAt(0);
                var tch = sentence[i].ToCharArray();
                Array.Copy(tch, 1, tch, 0, tch.Length - 1);
                tch[tch.Length - 1] = first;
                sentence[i] = new String(tch);
            }

            for (int i = 0; i < 8; i++)
            {
                var tmp = sentence[i].ToCharArray();
                for (int j = 0; j < 64; j++)
                {
                    ecran[i, j] = tmp[j];
                    if (ecran[i, j] == '1')
                        disp[i, j].BackColor = color;
                    else disp[i, j].BackColor = Color.Black;
                }
            }

        }

        public void LoadLetter(char l)
        {
            string res = "";
            StreamReader str = new StreamReader("MyFont.txt", Encoding.Default);
            while (!str.EndOfStream)
            {
                string st = str.ReadLine();
                if (st.EndsWith(l.ToString()))
                {
                    res = st;
                    break;
                }
            }
            str.Close();

            res = res.Remove(res.Length - 2, 2);
            string[] tmp = res.Split(' ');
            Array.Reverse(tmp);

            for (int i = 0; i < 8; i++)
            {
                sentence[i] += ReverseString(ToBinary(8, tmp[i]));
            }

        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }


    }
}
