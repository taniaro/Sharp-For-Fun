using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastSquaresMethod
{
    class Program
    {
        static string filepath = "info.txt";
        //максимальна степінь полінома
        const int MAXPOW = 10;

        //степінь полінома
        static int pow;
        public static int P 
        {
            get => pow; 
            set
            {
                if(value > MAXPOW)
                {
                    System.Console.WriteLine($"Степінь не може перевищувати {MAXPOW}");
                }
                else
                {
                    pow = value;
                }
            } 
        }

        //counts how much lines are in file
        static int FileSize()
        {
            int size = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        size++;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while reading file: {e.Message}");
            }

            return size;
        }

        //reading from file
        static void ReadFromFile(out double[] x, out double[] y, out int size)
        {
            size = FileSize();

            x = new double[size];
            y = new double[size];

            using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
            {
                string line;
                string[] tmp;
                int i = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    tmp = line.Split(' ');
                    x[i] = Convert.ToDouble(tmp[0]);
                    y[i] = Convert.ToDouble(tmp[1]);
                    i++;
                }
            }
        }
       

        static void Main(string[] args)
        {
            //масив коефіцієнтів, масив вільних членів системи, масиви для даних
            double[] result, freeParts, x, y;

            //
            double[,] sums;
            int N;
            double M;

            ReadFromFile(out x, out y, out N);
            Console.WriteLine("Отриманi данi: \nX:");
            foreach (var i in x)
                Console.Write(i + ", ");
            Console.WriteLine("\nY:");
            foreach (var i in y)
                Console.Write(i + ", ");
            Console.WriteLine("\n");

            Console.WriteLine("Введiть степiнь полiнома, яким апроксимуємо функцiю:");
            P = Convert.ToInt32(Console.ReadLine());

            result = new double[P + 1];
            freeParts = new double[P + 1];
            sums = new double[P + 1, P + 1];

            //шукаєм суми в системі рівнянь
            for (int i = 0; i < P + 1; i++)
            {
                for (int j = 0; j < P + 1; j++)
                {
                    sums[i,j] = 0;
                    for (int k = 0; k < N; k++)
                        sums[i,j] += Math.Pow(x[k], i + j);
                }
            }

            //заповнюєм рядок вільних членів для системи рівнянь
            for (int i = 0; i < P + 1; i++)
            {
                freeParts[i] = 0;
                for (int k = 0; k < N; k++)
                    freeParts[i] += Math.Pow(x[k], i) * y[k];
            }

            //гарне пояснення тут: https://prog-cpp.ru/gauss/ 
            //розв'язок системи рівнянь методом Гауса
            for (int k = 0; k < P + 1; k++)
            {
                for (int i = k + 1; i < P + 1; i++)
                {
                    //приводимо матрицю до трикутного вигляду, нормуєм рівняння
                    M = sums[i,k] / sums[k,k];
                    //віднімаєм отримані рядки від інших рядків, заміняєм відповідні коеф.
                    for (int j = k; j < P + 1; j++)
                        sums[i,j] -= M * sums[k,j];
                    freeParts[i] -= M * freeParts[k];
                }
            }

            //зворотня підстановка
            for (int i = P; i >= 0; i--)
            {
                double s = 0;
                for (int j = i; j < P + 1; j++)
                    s += sums[i,j] * result[j];
                result[i] = (freeParts[i] - s) / sums[i,i];
            }

            //вивід результату з заокругленням
            for(int i = 0; i < P + 1; i++)
            {
                double tmp = (result[i] > 0 ) ? Math.Round(result[i]) : Math.Ceiling(result[i]);
                Console.WriteLine($"X({i}) = {tmp}");
            }

        }
    }
}
