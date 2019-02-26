using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    class Program
    {
        //to do: 
        //1: user input
        //2: possibility of working not only with the console
        static void Main(string[] args)
        {
            int[] coefs = { 1, 2, 3, 4 };
            EquationSolver equationSolver = new EquationSolver(coefs, 30, 4);

            Console.WriteLine("Kind of equation: a*c1 + b*c2 + d*c3 + ... x*cn = res\n");
            Console.WriteLine($"Count of coefficients (N): {equationSolver.Coefficients.Length}\n");
            Console.WriteLine("Equation's coefficients (c1...cn): ");
            foreach (var i in equationSolver.Coefficients)
                Console.Write($"{i} ");
            Console.WriteLine("\n");
            Console.WriteLine($"Expected result (res): {equationSolver.EquationResult}\n");

            int index = equationSolver.Solve();
            if (index > 0)
            {
                Console.WriteLine("Expected values (a..x): ");
                Gene result = equationSolver[index - 1];
                foreach (var i in result.Alleles)
                    Console.Write($"{i} ");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No answers");
            }
            

        }
    }
}