using GeneticAlgorithm.Interfaces;

namespace TestClient.StringEvolver
{
    public class StringCrossover : ICrossoverAlgorithm<StringChromosome>
    {
        public void Crossover(StringChromosome chromosomeA, StringChromosome chromosomeB, double rate)
        {
            for (var i = 0; i < 39; i++)
            {
                if (StringChromosome.Generator.NextDouble() < rate)
                {
                    var helper = chromosomeA.Body[i];
                    chromosomeA.Body[i] = chromosomeB.Body[i];
                    chromosomeB.Body[i] = helper;
                }
            }
        }
    }
}