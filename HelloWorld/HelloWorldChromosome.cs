using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.HelloWorld
{
    public class HelloWorldChromosome
    {
        public static List<char> Genome = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                                                           'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                                           'o', 'p', 'q', 'r', 's', 't', 'u',
                                                           'v', 'w', 'x', 'y', 'z', 'A', 'B',
                                                           'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                                           'J', 'K', 'L', 'M', 'N', 'O', 'P',
                                                           'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                                                           'X', 'Y', 'Z', ' ', ',', '!' };

        public StringBuilder Body { get; set; }

        public HelloWorldChromosome()
        {
            Body = new StringBuilder(string.Empty);
        }

        public HelloWorldChromosome(HelloWorldChromosome chromosome)
            : this()
        {
            for (int i = 0; i < chromosome.Body.Length; i++)
            {
                Body.Append(chromosome.Body[i]);
            }
        }
    }
}