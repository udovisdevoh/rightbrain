using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linguistics;

namespace RightBrain
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTests.TestAll();

            #warning "Who are you" outputs "Me am"
            while (true)
            {
                string input = System.Console.ReadLine();
                string output = input.InvertFirstSecondPerson().InvertQuestion();
                System.Console.WriteLine(output);
            }
        }
    }
}
