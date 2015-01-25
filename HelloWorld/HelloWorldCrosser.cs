using GeneticAlgorithm.Interfaces;
using System;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldCrosser : ICrosser<HelloWorldChromosome>
    {
        private Random _randomNumberGenerator = new Random();

        public void Cross(HelloWorldChromosome chromosomeA, HelloWorldChromosome chromosomeB, double rate)
        {
            for (int i = 0; i < chromosomeA.Body.Length; i++)
            {
                if (_randomNumberGenerator.NextDouble() < rate)
                {
                    var temporary = chromosomeA.Body[i];
                    chromosomeA.Body[i] = chromosomeB.Body[i];
                    chromosomeB.Body[i] = temporary;
                }
            }
        }
    }
}