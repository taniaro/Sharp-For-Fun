using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    class Program
    {
        static void Main(string[] args)
        {
            Gene g1 = new Gene();
            Gene g2 = new Gene();
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 1, 2, 3, 4 };
            g1.Alleles = a;
            g2.Alleles = b;
            g1.Fitness = 63;
            g2.Fitness = 80;
            if(g1 == g2)
                Console.WriteLine("Equal genes");

        }
    }
}