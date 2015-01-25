namespace GeneticAlgorithm.Interfaces
{
    public interface ICrosser<HelloWorldChromosome>
    {
        void Cross(HelloWorldChromosome chromosomeA, HelloWorldChromosome chromosomeB, double rate);
    }
}