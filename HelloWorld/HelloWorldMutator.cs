using GeneticAlgorithm.Interfaces;
using System;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldMutator : IMutator<HelloWorldChromosome>
    {
        private Random _randomNumberGenerator = new Random();

        public void Mutate(HelloWorldChromosome chromosome, double rate)
        {
            for (int i = 0; i < chromosome.Body.Length; i++)
            {
                if (_randomNumberGenerator.NextDouble() < rate)
                {
                    chromosome.Body[i] = HelloWorldChromosome.Genome[_randomNumberGenerator.Next(HelloWorldChromosome.Genome.Count)];
                }
            }
        }
    }
}