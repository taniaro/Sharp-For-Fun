using System;
using System.Collections.Generic;
using System.Linq;


namespace SparseMatrix
{
    //клас для представлення матриці
    public partial class SparseMatrix
    {   //ім'я, масив клітинок матриці, масив розмірностей вимірів, значення за замовчуванням
        private string name;
        private List<SparseCell> cells;
        private List<int> dim;
        private int def;

        public SparseMatrix() : this("sparse matrix")
        {
            Console.WriteLine("created: " + name);
            cells = new List<SparseCell>();
            dim = new List<int>();
        }
        public SparseMatrix(string name)
        {
            this.name = name;
            Console.WriteLine("created: " + name);
            cells = new List<SparseCell>();
            dim = new List<int>();
        }

        public SparseMatrix(SparseMatrix s)
        {
            name = s.name + "_copy";
            def = s.def;
            dim = s.dim;
            cells = s.cells;
        }

        public SparseMatrix Clone()
        {
            SparseMatrix i = new SparseMatrix(this);
            return i;
        }
        public void setDef(int d) { def = d; }
        public void setName(string s)
        {
            if (s != "" && s != " ")
                name = s;
            else
                Console.WriteLine("Cannot rename to spase or empty symbol");
        }
        public string getName() { return name; }
        public void addToDim(int n) { dim.Add(n); }
        public int dimSize() { return dim.Count; }

    }

    partial class SparseMatrix
    {
        //знаходження розміру виміру за номером його позиції
        public int getSize(int dm)
        {
            int i = -1;
            try
            {
                i = dim.ElementAt(dm - 1);
            } catch(Exception e)
            {
                Console.WriteLine("Error, try again");
            }
            return i;
        }

        //встановлення розмірності виміру за номером його позиції
        public void setSize(int dm, int size)
        {
            try
            {
                dim[dm - 1] = size;
            }
            catch (Exception e)
            {
                Console.WriteLine("Offset error, try again");
            }
        }

        //встановлення значення комірки матриці за її координатами
        public void setValue(int val, List<int> crd)
        {
            if(crd.Count > dim.Count || crd.Count < dim.Count)
            {
                Console.WriteLine("Wrong index - too long");
                return;
            }
            else
            {
                for(int i=0; i<dim.Count; i++)
                {
                    if(crd[i] > dim[i])
                    {
                        Console.WriteLine("Wrong index at position {0} - too long", i+1);
                        return;
                    }
                }
            }
            cells.Add(new SparseCell(val, crd));
        }

        //знаходження значення з комірки за її координатами
        public int getValue(List<int> crd)
        {
            int r = def;
            for (int i = 0; i < cells.Count; i++)
            {
                bool flag = true;
                for(int j=0; j < crd.Count; j++)
                {
                    if (crd[j] != cells[i].coord[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    r = cells[i].value;
                    break;
                }
            }
            return r;
        }

        //для виведення інформації про розмірності вимірів матриці
        public string SizeInfo()
        {
            string i = "";
            if (dim == null) i = "size: []";
            else
            {
                i += "size: [";
                for(int j=0; j < dim.Count - 1; j++)
                {
                    i += dim[j].ToString();
                    i += ",";
                }

                i += dim[dim.Count-1].ToString();
                i += "]";
            }
            return i;
        }

        //виведення інформації про всі клітинки матриці
        public string MatrixInfo()
        {
            string info = "";
            if (dim.Count == 0) info = "size: [] values: []";
            info += SizeInfo();
            info += " values: [";

            int count = 1;
            for (int i = 0; i < dim.Count; i++)
                count *= dim.ElementAt(i);

            int steps = 0;
            List<int> temp = new List<int>();
            for(int i=0; i<dim.Count; i++)
                temp.Add(0);

            while(steps < count)
            {
                steps++;
                int val = getValue(temp);
                info += "[";

                for (int i = 0; i < temp.Count - 1; i++)
                {
                    info += temp.ElementAt(i) + ",";
                }
                info += temp.ElementAt(temp.Count - 1) + "]:";
                info += val.ToString() + " ";

                bool flag = true;
                for (int i = temp.Count - 1; i >= 0 && flag; i--)
                {
                    flag = false;
                    temp[i]++;
                    if (temp[i] >= dim[i])
                    {
                        temp[i] = 0;
                        flag = true;
                    }
                }
            }

            info += "]";
            return info;
        }
    }
}
