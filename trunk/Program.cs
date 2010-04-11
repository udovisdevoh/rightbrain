using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linguistics;
using Linguistics.English;
using WebServices;

namespace RightBrain
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleChatBot googleChatBot = new GoogleChatBot();

            Random random = new Random();

            #warning "Who are you" outputs "Me am"
            while (true)
            {
                string input = System.Console.ReadLine();
                string output = input.InvertFirstSecondPerson();

                if (output.IsQuestion() || output.IsImperative())
                    output = output.InvertQuestion();

                if (output.Trim().ToLowerInvariant().StartsWith("because"))
                    output = output.RemoveWord(0, true);

                /*string invertedOutput = output.InvertNegation();
                if (!invertedOutput.StartsWith("It's not like"))
                    output = invertedOutput;*/

                output = googleChatBot.TryExpandString(output, random);

                System.Console.WriteLine(output);
            }
        }
    }
}
