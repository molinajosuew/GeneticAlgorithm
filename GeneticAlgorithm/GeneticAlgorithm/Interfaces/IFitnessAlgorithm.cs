namespace GeneticAlgorithm.Interfaces
{
    public interface IFitnessAlgorithm<ChromosomeType>
    {
        double Fitness(ChromosomeType chromosome);
    }
}