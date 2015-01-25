using GeneticAlgorithm.Components;
using GeneticAlgorithm.Interfaces;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldElitism : IElitism<HelloWorldChromosome>
    {
        public IFitnessCalculator<HelloWorldChromosome> FitnessCalculator { get; set; }

        public HelloWorldChromosome[] GetElite(Population<HelloWorldChromosome> population)
        {
            return new HelloWorldChromosome[] { population[population.Size - 1], population[population.Size - 2] };
        }
    }
}