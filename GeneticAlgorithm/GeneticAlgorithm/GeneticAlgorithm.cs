using GeneticAlgorithm.Interfaces;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class GeneticAlgorithm<ChromosomeType>
    {
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }

        public IFitnessAlgorithm<ChromosomeType> FitnessAlgorithm { get; set; }
        public IElitismAlgorithm<ChromosomeType> ElitismAlgorithm { get; set; }
        public ISelectionAlgorithm<ChromosomeType> SelectionAlgorithm { get; set; }
        public ICrossoverAlgorithm<ChromosomeType> CrossoverAlgorithm { get; set; }
        public IMutationAlgorithm<ChromosomeType> MutationAlgorithm { get; set; }

        internal List<ChromosomeType> CurrentGeneration { get; set; }

        internal double EvaluateFitness(ChromosomeType chromosome)
        {
            return FitnessAlgorithm.Fitness(chromosome);
        }
        internal List<ChromosomeType> GetElites()
        {
            return ElitismAlgorithm.Elitism(CurrentGeneration);
        }
        internal ChromosomeType Select()
        {
            return SelectionAlgorithm.Selection(CurrentGeneration, FitnessAlgorithm);
        }
        internal void Crossover(ChromosomeType chromosomeA, ChromosomeType chromosomeB)
        {
            CrossoverAlgorithm.Crossover(chromosomeA, chromosomeB, CrossoverRate);
        }
        internal void Mutate(ChromosomeType chromosome)
        {
            MutationAlgorithm.Mutation(chromosome, MutationRate);
        }

        public void SetPrimordialSoup(List<ChromosomeType> generation)
        {
            CurrentGeneration = generation;
            CurrentGeneration.Sort((a, b) => EvaluateFitness(b).CompareTo(EvaluateFitness(a)));
        }
        public void RunOneGeneration()
        {
            var FutureGeneration = new List<ChromosomeType>(GetElites());

            while (FutureGeneration.Count < CurrentGeneration.Count)
            {
                var chromosomeA = Select();
                var chromosomeB = Select();

                Crossover(chromosomeA, chromosomeB);

                Mutate(chromosomeA);
                Mutate(chromosomeB);

                FutureGeneration.Add(chromosomeA);
                FutureGeneration.Add(chromosomeB);
            }

            CurrentGeneration = FutureGeneration;
            FutureGeneration = new List<ChromosomeType>();
            CurrentGeneration.Sort((a, b) => EvaluateFitness(b).CompareTo(EvaluateFitness(a)));
        }
    }
}