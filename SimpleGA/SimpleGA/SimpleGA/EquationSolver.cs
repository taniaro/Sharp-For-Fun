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
        int ALLOW_MUTATION = 3;

        public int[] Coefficients { get; }
        public int EquationResult { get; }
        Gene[] population;
        Random random;

        public Gene this[int i] { get => population[i]; }

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

        //there is a bug (returns "no answers" smt)...need to fix later
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
         * Calculates fitness function (g.Fitness) for gene 
         * as a difference between absolute equation result 
         * and gene's equation result
         * In the best case it's value must be 0 **/
        void Fitness(ref Gene g)
        {
            int temp = 0;
            for (int i = 0; i < COEFF_COUNT; i++)
                temp += g.Alleles[i] * Coefficients[i];
            g.Fitness = Math.Abs(temp - EquationResult);
        }

        /** 
         * Calculates average fitness value for population **/
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

        /**
         * Creates new population based on kids of parents,
         * whose fitness function value is less then average**/

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

                kid = Breed(parent1, parent2); 
                if (iteration >= ALLOW_MUTATION)
                    Mutation(kid);
                Fitness(ref kid);
                AddToPopulation(kid); 
            }

            //True if population has free places to insert new kids
            //Free place's marks are -1 fitness value and -1 at every Alleles' position
            //(we just check fir's Alleles' position)
            bool NotFull()
            {
                for (int i = 0; i < MAXPOP; i++)
                    if ((population[i].Fitness == -1) && (population[i].Alleles[0] == -1))
                        return true;

                return false;
            }
        }

        /**
         * Creates kid using crossover **/

        Gene Breed(int parent1, int parent2)
        {
            Gene kid = population[parent1];
            int crossover = random.Next() % COEFF_COUNT + 1;
            int initial_place = crossover, fin = COEFF_COUNT - 1;

            for (int i = initial_place; i < fin; i++)
                kid.Alleles[i] = population[parent2].Alleles[i];

            return kid;
        }

        /**
         * Simple mutation(+1 or -1 from allele's value) **/

        void Mutation(Gene kid)
        {
            Fitness(ref kid);
            int f = kid.Fitness;

            int coef = 0;
            coef = random.Next() % COEFF_COUNT;

            if (f <= 0)
                kid.Alleles[coef]++;
            else
                kid.Alleles[coef]--;
        }

        /**
         * Adds new kids to an existing population **/
        void AddToPopulation(Gene kid)
        {
            for (int i = 0; i < MAXPOP; i++)
            {
                if (population[i].Fitness == -1 && population[i].Alleles[0] == -1)
                {
                    for (int j = 0; j < COEFF_COUNT; j++)
                        population[i].Alleles[j] = kid.Alleles[j];

                    population[i].Fitness = kid.Fitness;
                    break;
                }

            }
        }

    }
}
