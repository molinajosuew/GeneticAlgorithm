namespace GeneticAlgorithm.Interfaces
{
    public interface IMutator<HelloWorldChromosome>
    {
        void Mutate(HelloWorldChromosome chromosome, double rate);
    }
}