using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGA
{
    public class EquationSolver
    {
        const int MAXPOP = 25;
        int COEFF_COUNT;

        public int[] Coefficients { get; }
        public int EquationResult { get; }
        Gene[] population;
        Random random;

        public EquationSolver(int[] Coefficients, int EquationResult, int COEFF_COUNT)
        {
            this.Coefficients = Coefficients;
            this.EquationResult = EquationResult;
            this.COEFF_COUNT = COEFF_COUNT;
            Gene.ALLELES_COUNT = COEFF_COUNT;
            random = new Random();

            population = new Gene[MAXPOP];
            for (int i = 0; i < MAXPOP; i++)
                population[i] = new Gene();

        }

        /** This method fully solves the equation**/
        public int Solve()
        {
            int fitness = -100;
            // creation of random values for 1st population

            for (int i = 0; i < MAXPOP; i++)
                for (int j = 0; j < COEFF_COUNT; j++)
                    population[i].Alleles[j] = random.Next() % EquationResult;

            for (int i = 0; i < MAXPOP; i++)
                Fitness(ref population[i]);

            int iter = 0;
            while (fitness <= 0)
            {
                AverageFitnesses();
                CreateNewPopulation(iter);
                fitness = Check();
                iter++;
                if (iter > 50) break;
            }
            return fitness;

            //Checks if we have some good gene with Fitness == 0
            //Returns position of this gene
            int Check()
            {
                for (int i = 0; i < MAXPOP; i++)
                {
                    if (population[i].Fitness == 0)
                        return i + 1;
                }
                return 0;
            }
        }


        /** 
         * Calculates fitness function for every gene in population 
         * as a difference between absolute equation result 
         * and gene's equation result **/
        void Fitness(ref Gene g)
        {
            int temp = 0;
            for (int i = 0; i < COEFF_COUNT; i++)
                temp += g.Alleles[i] * Coefficients[i];
            g.Fitness = Math.Abs(temp - EquationResult);
        }

        /** 
         * Calculates average fitness meaning for population **/
        void AverageFitnesses()
        {
            int avg = 0;
            for (int i = 0; i < MAXPOP; i++)
                avg += population[i].Fitness;

            avg /= MAXPOP;

            for (int i = 0; i < MAXPOP; i++)
            {
                if (population[i].Fitness > avg)
                {
                    for (int j = 0; j < COEFF_COUNT; j++)
                        population[i].Alleles[j] = -1;

                    population[i].Fitness = -1;
                }
            }
        }


        void CreateNewPopulation(int iteration)
        {
            int parent1, parent2;
            Gene kid;
            Array.Sort(population);

            int cnt = 0;
            for (int i = 0; i < MAXPOP; i++, cnt++)
            {
                if (population[i].Fitness == -1)
                    break;
            }

            while (NotFull())
            {
                parent1 = random.Next() % cnt;
                parent2 = random.Next() % cnt;

                kid = Breed(parent1, parent2); //not implemented
                if (iteration >= 5)
                    Mutation(kid); //not implemented
                Fitness(ref kid);
                AddToPopulation(kid); //not implemented
            }

            //True if population has free places to insert new kids
            bool NotFull()
            {
                for (int i = 0; i < MAXPOP; i++)
                    if ((population[i].Fitness == -1) && (population[i].Alleles[0] == -1))
                        return true;

                return false;
            }
        }

        Gene Breed(int parent1, int parent2)
        {
            return new Gene();
        }

        void Mutation(Gene kid)
        {

        }

        void AddToPopulation(Gene kid)
        {

        }

    }
}
