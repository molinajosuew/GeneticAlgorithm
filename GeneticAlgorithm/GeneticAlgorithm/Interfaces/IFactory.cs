namespace GeneticAlgorithm.Interfaces
{
    public interface IFactory<HelloWorldChromosome>
    {
        HelloWorldChromosome CreateChromosome();
    }
}