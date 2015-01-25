using GeneticAlgorithm.Components;

namespace GeneticAlgorithm.Interfaces
{
    public interface ISelector<HelloWorldChromosome>
    {
        HelloWorldChromosome Select(Population<HelloWorldChromosome> population);
    }
}