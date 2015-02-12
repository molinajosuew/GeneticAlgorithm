namespace GeneticAlgorithm.Interfaces
{
    public interface IMutationAlgorithm<ChromosomeType>
    {
        void Mutation(ChromosomeType chromosome, double rate);
    }
}