using System.Collections.Generic;

namespace GeneticAlgorithm.Interfaces
{
    public interface IElitismAlgorithm<ChromosomeType>
    {
        List<ChromosomeType> Elitism(List<ChromosomeType> generation);
    }
}