using System.Collections.Generic;

namespace GeneticAlgorithm.Interfaces
{
    public interface ISelectionAlgorithm<ChromosomeType>
    {
        ChromosomeType Selection(List<ChromosomeType> generation, IFitnessAlgorithm<ChromosomeType> fitnessAlgorithm);
    }
}