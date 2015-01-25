namespace GeneticAlgorithm.Interfaces
{
    public interface IFitnessCalculator<HelloWorldChromosome>
    {
        double Fitness(HelloWorldChromosome chromosome);
    }
}