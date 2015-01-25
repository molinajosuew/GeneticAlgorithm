using GeneticAlgorithm.Components;
using GeneticAlgorithm.Interfaces;
using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldSelector : ISelector<HelloWorldChromosome>
    {
        #region Fields

        private Random _randomNumberGenerator = new Random();

        #endregion

        #region Properties

        public IFitnessCalculator<HelloWorldChromosome> FitnessCalculator { get; set; }

        #endregion

        #region Methods

        public HelloWorldChromosome Select(Population<HelloWorldChromosome> population)
        {
            population.Sort();
            var fitnessTotal = 0d;

            for (int i = 0; i < population.Size; i++)
            {
                fitnessTotal += FitnessCalculator.Fitness(population[i]);
            }

            var fitnessSum = FitnessCalculator.Fitness(population[0]);
            var result = new HelloWorldChromosome(population[0]);
            var rouletteWheel = _randomNumberGenerator.NextDouble();

            for (var i = 1; fitnessSum / fitnessTotal <= rouletteWheel; i++)
            {
                fitnessSum += FitnessCalculator.Fitness(population[i]);
                result = new HelloWorldChromosome(population[i]);
            }

            return result;
        }
        private bool _IsSortedAscending(List<HelloWorldChromosome> population)
        {
            for (var i = 0; i < population.Count - 1; i++)
            {
                if (FitnessCalculator.Fitness(population[i]) > FitnessCalculator.Fitness(population[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}