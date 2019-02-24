using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    class Gene
    {
        static readonly int ALLELES_COUNT = 4;

        public int[] Alleles { get; set; }
        public int Fitness { get; set; }

        public static bool operator ==(Gene g1, Gene g2)
        {
            for (int i = 0; i < ALLELES_COUNT; i++)
                if (g1.Alleles[i] != g2.Alleles[i])
                    return false;
            return true;
        }

        public static bool operator !=(Gene g1, Gene g2)
        {
            return !(g1 == g2);
        }

        public static bool operator >(Gene g1, Gene g2)
        {
            return g1.Fitness > g2.Fitness;
        }

        public static bool operator <(Gene g1, Gene g2)
        {
            return g1.Fitness < g2.Fitness;
        }
    }
}
