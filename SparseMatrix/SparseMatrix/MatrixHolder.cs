using System;
using System.Collections.Generic;


namespace SparseMatrix
{
    //клас для роботи з списком матриць
    public class MatrixHolder
    {
        public List<SparseMatrix> holder; 

        public MatrixHolder() { holder = new List<SparseMatrix>(); }

        public void AddMat(string args)
        {
            var a = args.Split(' ');
            int dim;
            Int32.TryParse(a[0], out dim);
            int minlength = dim + 2;
            int maxlength = dim + 3;
            int length = a.Length;

            if(dim == 0 || length>maxlength || length < minlength)
            {
                Console.WriteLine("Problem with arguments, try again");
                return;
            }

            SparseMatrix matrix = (length > minlength) ? new SparseMatrix(a[length - 1] == "" ? "sparse matrix" : a[length-1])
                                                        : new SparseMatrix();

            for (int i = 1; i <= dim; i++)
                matrix.addToDim(0);

            int temp = 0;
            for (int i = 1; i <= dim; i++)
            {
                Int32.TryParse(a[i], out temp);
                matrix.setSize(i, temp);
            }

            int ourdef;
            int defpos = (length == maxlength) ? 2 : 1;
            Int32.TryParse(a[length - defpos], out ourdef);
            matrix.setDef(ourdef);

            holder.Add(matrix);
            Console.WriteLine("Matrix was sucsessfully created!");
        }

        public void List()
        {
            if (holder.Count == 0)
            {
                Console.WriteLine("Empty list");
                return;
            }
            Console.WriteLine("Our elements:");
            for (int i=0; i<holder.Count; i++)
                Console.WriteLine($"[{i}] : {holder[i].getName()} , {holder[i].SizeInfo()}");
        }

        public void Del(int pos)
        {
            Console.WriteLine($"{holder[pos].getName()} will be deleted");
            try
            {
                holder.RemoveAt(pos);
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured: maybe wrong position number");
                return;
            }
        }

        public void DelAll()
        {
            holder.Clear();
            Console.WriteLine("Everything is deleted");
        }

        public void Def(string args)
        {
            try
            {
                var a = args.Split(' ');
                int pos; Int32.TryParse(a[0], out pos);
                int args_expected = holder[pos].dimSize();
                int val; Int32.TryParse(a[a.Length - 1], out val);
                List<int> param = new List<int>();

                int temp = 0;
                for (int i = 1; i <= args_expected; i++)
                {
                    Int32.TryParse(a[i], out temp);
                    param.Add(temp);
                }

                if (param.Count != args_expected)
                {
                    Console.WriteLine("An error occured, problem with arguments");
                    return;
                }

                holder[pos].setValue(val, param);

            } catch(Exception e)
            {
                Console.WriteLine("Arguments error, try again");
            }
        }

        public void Print(int pos)
        {
            try
            {
                Console.WriteLine(holder[pos].MatrixInfo());
            }
            catch(Exception e)
            {
                Console.WriteLine("Matrix not found");
            }
        }

        public void CloneMatrix(int pos)
        {
            try
            {
                SparseMatrix temp = new SparseMatrix(holder[pos]);
                holder.Add(temp);
            }
            catch(Exception e)
            {
                Console.WriteLine("Matrix not found");
            }
        }

        public void Rename(string args)
        {
            try
            {
                var a = args.Split(' ');
                int pos;
                Int32.TryParse(a[0], out pos);
                string name = a[1];
                holder[pos].setName(name);
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured");
            }
        } 

        public void Example()
        {
            Console.WriteLine("//Додаємо нову матрицю до списку: ");
            Console.WriteLine(">addmat 2 3 4 1 matrix");
            AddMat("2 3 4 1 matrix");
            Console.WriteLine("//Зробимо її копію: ");
            Console.WriteLine(">clone 0");
            CloneMatrix(0);
            Console.WriteLine("//Перегляд інформації про матриці: ");
            Console.WriteLine(">list");
            List();
            Console.WriteLine("//Встановимо значення елемента першої матриці з координатами 2, 2 як 18:");
            Console.WriteLine(">def 0 2 2 18");
            Def("0 2 2 18");
            Console.WriteLine("//Виведемо інформацію про першу матрицю: ");
            Console.WriteLine(">print 0");
            Print(0);
            Console.WriteLine("//Видалимо першу матрицю: ");
            Console.WriteLine(">del 0");
            Del(0);
            Console.WriteLine("//Як тепер виглядає список: ");
            Console.WriteLine(">list");
            List();
            Console.WriteLine("//Перейменуємо матрицю яка залишилась на helloworld: ");
            Console.WriteLine(">rename 0 helloworld");
            Rename("0 helloworld");
            Console.WriteLine("//Стало: ");
            Console.WriteLine(">list");
            List();
            Console.WriteLine("//Видалимо всі елементи які були: ");
            Console.WriteLine(">delall");
            DelAll();
            Console.WriteLine("Приємного користування!");


        }

    }
}
