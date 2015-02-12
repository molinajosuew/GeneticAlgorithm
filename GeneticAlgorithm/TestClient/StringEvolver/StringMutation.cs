using GeneticAlgorithm.Interfaces;

namespace TestClient.StringEvolver
{
    public class StringMutation : IMutationAlgorithm<StringChromosome>
    {
        public void Mutation(StringChromosome chromosome, double rate)
        {
            for (var i = 0; i < 39; i++)
            {
                if (StringChromosome.Generator.NextDouble() < rate)
                {
                    chromosome.Body[i] = (char)StringChromosome.Generator.Next('a', 'z' + 2);
                }
            }
        }
    }
}