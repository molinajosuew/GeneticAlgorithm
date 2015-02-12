using GeneticAlgorithm.Interfaces;
using System;
using System.Collections.Generic;

namespace TestClient.StringEvolver
{
    public class StringSelection : ISelectionAlgorithm<StringChromosome>
    {
        public StringChromosome Selection(List<StringChromosome> chromosomes, IFitnessAlgorithm<StringChromosome> fitnessAlgorithm)
        {
            var sum = 0d;

            foreach (var chromosome in chromosomes)
            {
                sum += fitnessAlgorithm.Fitness(chromosome);
            }

            var pointer = 0d;
            var target = StringChromosome.Generator.NextDouble();

            for (var i = chromosomes.Count - 1; i >= 0; i--)
            {
                pointer += sum != 0 ? fitnessAlgorithm.Fitness(chromosomes[i]) / sum : 1d / chromosomes.Count;

                if (pointer > target)
                {
                    return new StringChromosome(chromosomes[i]);
                }
            }

            throw new Exception("There was a problem with the selection algorithm.");
        }
    }
}