using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linguistics;

namespace RightBrain
{
    static class UnitTests
    {
        #region Public Methods
        public static void TestAll()
        {
            TestStringManipulations();
            TestLinguisticsTransformations();
        }
        #endregion

        #region Private Methods
        private static void TestStringManipulations()
        {
            AssertEquals("I like musIc".ReplaceWordInsensitiveLower("music", "FooD"), "i like food");
            AssertEquals("Better is better".ReplaceWordKeepCase("better", "worse"), "Worse is worse");
            AssertEquals("You think YOU are the one, do you?".ReplaceWordKeepCase("you", "i"), "Vous think VOUS are the one, do vous?");
        }

        private static void TestLinguisticsTransformations()
        {
            AssertEquals(Transformations.InvertFirstSecondPerson("I love you"), "You love me");
            AssertEquals(Transformations.InvertFirstSecondPerson("You love me"), "I love you");

            AssertEquals(Transformations.InvertFirstSecondPerson("I listen to you"), "You listen to me");
            AssertEquals(Transformations.InvertFirstSecondPerson("You listen to me"), "I listen to you");

            AssertEquals(Transformations.InvertFirstSecondPerson("This is my hat"), "This is your hat");
            AssertEquals(Transformations.InvertFirstSecondPerson("This is your hat"), "This is my hat");

            AssertEquals(Transformations.InvertFirstSecondPerson("I'm the best"), "You're the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You're the best"), "I'm the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("I am the best"), "You are the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You are the best"), "I am the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("You will be rewarded"), "I will be rewarded");
            AssertEquals(Transformations.InvertFirstSecondPerson("I will be rewarded"), "You will be rewarded");

            AssertEquals(Transformations.InvertFirstSecondPerson("You'll be rewarded"), "I'll be rewarded");
            AssertEquals(Transformations.InvertFirstSecondPerson("I'll be rewarded"), "You'll be rewarded");

            AssertEquals(Transformations.InvertFirstSecondPerson("This hat is yours"), "This hat is mine");
            AssertEquals(Transformations.InvertFirstSecondPerson("This hat is mine"), "This hat is yours");

            AssertEquals(Transformations.InvertFirstSecondPerson("You will do it by yourself"), "I will do it by myself");
            AssertEquals(Transformations.InvertFirstSecondPerson("I will do it by myself"), "You will do it by yourself");
        }

        private static void AssertEquals(string string1, string string2)
        {
            if (string1 != string2)
                throw new Exception("Wrong value: "+string2 +" should equals: "+string1);
        }
        #endregion
    }
}
