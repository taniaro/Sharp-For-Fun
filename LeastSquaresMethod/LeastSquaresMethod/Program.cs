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
        public static int K;

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

            x = new double[size + 1];
            y = new double[size + 1];

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

            double[] result, freeParts, x, y;
            double[,] sums;

            int N;
            double M, s;

            ReadFromFile(out x, out y, out N);

            K = 2;

            result = new double[K + 1];
            freeParts = new double[K + 1];
            sums = new double[K + 1, K + 1];

            for (int i = 0; i < K + 1; i++)
            {
                for (int j = 0; j < K + 1; j++)
                {
                    sums[i,j] = 0;
                    for (int k = 0; k < N; k++)
                        sums[i,j] += Math.Pow(x[k], i + j);
                }
            }

            for (int i = 0; i < K + 1; i++)
            {
                freeParts[i] = 0;
                for (int k = 0; k < N; k++)
                    freeParts[i] += Math.Pow(x[k], i) * y[k];
            }


            for (int k = 0; k < K + 1; k++)
            {
                for (int i = k + 1; i < K + 1; i++)
                {
                    M = sums[i,k] / sums[k,k];
                    for (int j = k; j < K + 1; j++)
                        sums[i,j] -= M * sums[k,j];
                    freeParts[i] -= M * freeParts[k];
                }
            }


            for (int i = K; i >= 0; i--)
            {
                s = 0;
                for (int j = i; j < K + 1; j++)
                    s += sums[i,j] * result[j];
                result[i] = (freeParts[i] - s) / sums[i,i];
            }

            for(int i = 0; i < K + 1; i++)
            {
                double tmp = result[i];//(result[i] > 0 ) ? Math.Round(result[i]) : Math.Ceiling(result[i]);
                Console.WriteLine($"X({i}) = {tmp}");
            }

        }
    }
}
