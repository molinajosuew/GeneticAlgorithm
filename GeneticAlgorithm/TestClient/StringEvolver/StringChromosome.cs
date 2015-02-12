using System;
using System.Text;

namespace TestClient.StringEvolver
{
    public class StringChromosome
    {
        public static Random Generator { get; set; }
        public StringBuilder Body { get; set; }

        static StringChromosome()
        {
            Generator = new Random();
        }
        public StringChromosome()
        {
            Body = new StringBuilder();

            for (var i = 0; i < 39; i++)
            {
                Body.Append((char)Generator.Next('a', 'z' + 2));
            }
        }
        public StringChromosome(StringChromosome chromosome)
        {
            Body = new StringBuilder(chromosome.Body.ToString());
        }
    }
}