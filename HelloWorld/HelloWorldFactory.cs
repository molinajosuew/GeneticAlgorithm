using GeneticAlgorithm.Interfaces;
using System;
using System.Text;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldFactory : IFactory<HelloWorldChromosome>
    {
        private Random _randomNumberGenerator = new Random();

        public HelloWorldChromosome CreateChromosome()
        {
            var chromosome = new HelloWorldChromosome();

            for (int i = 0; i < 13; i++)
            {
                chromosome.Body.Append(HelloWorldChromosome.Genome[_randomNumberGenerator.Next(HelloWorldChromosome.Genome.Count)]);
            }

            return chromosome;
        }
    }
}