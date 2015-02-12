namespace GeneticAlgorithm.Interfaces
{
    public interface ICrossoverAlgorithm<ChromosomeType>
    {
        void Crossover(ChromosomeType chromosomeA, ChromosomeType chromosomeB, double rate);
    }
}