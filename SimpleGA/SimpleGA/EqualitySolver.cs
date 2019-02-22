using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    class EqualitySolver
    {
        static readonly int COEFF_COUNT = 4;

        public int[] Coefficients { get; }
        public int EquationResult { get; }
        Gene[] population;

        public EqualitySolver(int[] Coefficients, int EquationResult)
        {
            this.Coefficients = Coefficients;
            this.EquationResult = EquationResult;
        }

        public void Fitness(ref Gene g)
        {
            int temp = 0;
            for (int i = 0; i < COEFF_COUNT; i++)
                temp += g.Alleles[i] * Coefficients[i];
            g.Fitness = Math.Abs(temp - EquationResult);
        }


    }
}
