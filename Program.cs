using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linguistics;
using Linguistics.English;

namespace RightBrain
{
    class Program
    {
        static void Main(string[] args)
        {
            #warning "Who are you" outputs "Me am"
            while (true)
            {
                string input = System.Console.ReadLine();
                string output = input.InvertFirstSecondPerson();

                if (output.IsQuestion())
                    output = output.InvertQuestion();

                System.Console.WriteLine(output);
                System.Console.WriteLine(output.InvertNegation());
            }
        }
    }
}
