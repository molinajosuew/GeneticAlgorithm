using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using TestClient.StringEvolver;

namespace TestClient
{
    public static class Program
    {
        public static void Main()
        {
            var ga = new GeneticAlgorithm<StringChromosome>
            {
                FitnessAlgorithm = new StringFitness(),
                ElitismAlgorithm = new StringElitism(),
                SelectionAlgorithm = new StringSelection(),
                CrossoverAlgorithm = new StringCrossover(),
                MutationAlgorithm = new StringMutation(),
                CrossoverRate = 0.75,
                MutationRate = 0.05
            };

            var primordialSoup = new List<StringChromosome>();

            for (int i = 0; i < 10; i++)
            {
                primordialSoup.Add(new StringChromosome());
            }

            ga.SetPrimordialSoup(primordialSoup);

            var bestList = new List<string> { ga.GetCurrentGeneration()[0].Body.ToString() };

            while (ga.GetCurrentGeneration()[0].Body.ToString() != "this{is{a{test{of{the{genetic{algorithm")
            {
                ga.RunOneGeneration();

                if (!bestList.Contains(ga.GetCurrentGeneration()[0].Body.ToString()))
                {
                    bestList.Add(ga.GetCurrentGeneration()[0].Body.ToString());
                }
            }

            foreach (var chromosome in bestList)
            {
                Console.WriteLine(chromosome.Replace('{', ' '));
            }
        }
    }
}