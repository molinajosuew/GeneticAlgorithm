using GeneticAlgorithm.Interfaces;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldFitnessCalculator : IFitnessCalculator<HelloWorldChromosome>
    {
        public double Fitness(HelloWorldChromosome chromosome)
        {
            var result = 0d;

            for (int i = 0; i < chromosome.Body.Length; i++)
            {
                if (chromosome.Body[i] == "Hello, world!"[i])
                {
                    result += 1;
                }
            }

            return result;
        }
    }
}