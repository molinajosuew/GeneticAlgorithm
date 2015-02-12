using GeneticAlgorithm.Interfaces;

namespace TestClient.StringEvolver
{
    public class StringFitness : IFitnessAlgorithm<StringChromosome>
    {
        public double Fitness(StringChromosome chromosome)
        {
            var fitness = 0;

            for (var i = 0; i < 39; i++)
            {
                fitness += chromosome.Body[i] == "this{is{a{test{of{the{genetic{algorithm"[i] ? 1 : 0;
            }

            return fitness;
        }
    }
}