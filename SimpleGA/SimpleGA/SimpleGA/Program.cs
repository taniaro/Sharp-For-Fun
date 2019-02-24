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
            int[] coefs = { 1, 2, 3, 4 };
            EquationSolver equationSolver = new EquationSolver(coefs, 30, 4);

            equationSolver.Solve();

        }
    }
}