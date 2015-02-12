using GeneticAlgorithm.Interfaces;
using System.Collections.Generic;

namespace TestClient.StringEvolver
{
    public class StringElitism : IElitismAlgorithm<StringChromosome>
    {
        public List<StringChromosome> Elitism(List<StringChromosome> chromosomes)
        {
            return new List<StringChromosome> { chromosomes[0], chromosomes[1] };
        }
    }
}