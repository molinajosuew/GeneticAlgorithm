using GeneticAlgorithm.Components;

namespace GeneticAlgorithm.Interfaces
{
    public interface IElitism<ChromosomeType>
    {
        ChromosomeType[] GetElite(Population<ChromosomeType> population);
    }
}