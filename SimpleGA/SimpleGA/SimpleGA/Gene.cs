using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    public class Gene : IComparable<Gene>
    {
        public static int ALLELES_COUNT { get; set; }

        public int[] Alleles { get; set; }
        public int Fitness { get; set; }

        public Gene()
        {
            Alleles = new int[ALLELES_COUNT];
            for (int i = 0; i < ALLELES_COUNT; i++)
                Alleles[i] = 0;
        }

        public int CompareTo(Gene other)
        {
            //I want to sort in descending order, so I put "-" here
            return -(this.Fitness.CompareTo(other.Fitness));
        }

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
