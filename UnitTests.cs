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
            TestLinguisticsAnalysis();
            TestLinguisticsTransformations();
        }
        #endregion

        #region Private Methods
        private static void TestStringManipulations()
        {
            TestInsensitiveReplaceToLower();
            TestRemoveWord();
            TestInsertWords();
            TestInvertWords();
        }

        private static void TestCountWords()
        {
            AssertEquals("gfdg dfg dfhdgfd,gdfgmdfmgmmgf gfsdf,sdgf   dfgdfg,sdf  sdfsdfsdf! dfg asdsdgggh  hghfh".CountWords(), 12);
        }

        private static void TestInsertWords()
        {
            AssertEquals("one two tree".InsertWords("mofo", 0), "mofo one two tree");
            AssertEquals("one two tree".InsertWords("mofo", 1), "one mofo two tree");
            AssertEquals("one two tree".InsertWords("mofo", 2), "one two mofo tree");
        }

        private static void TestInvertWords()
        {
            AssertEquals("you are dumb".InvertWordPosition(0, 1), "are you dumb");
            AssertEquals("you are dumb".InvertWordPosition(1, 0), "are you dumb");
            AssertEquals("you are dumb".InvertWordPosition(1, 2), "you dumb are");
            AssertEquals("you are dumb".InvertWordPosition(2, 1), "you dumb are");
        }

        private static void TestRemoveWord()
        {
            //Remove words by name
            AssertEquals("I do not watch you.".RemoveWord("not"), "I do watch you.");
            AssertEquals("I see blue mountains and blue dogs".RemoveWord("blue"), "I see mountains and dogs");
            AssertEquals("I see blue mountains and blue dogs".RemoveWord("blue", 1), "I see mountains and blue dogs");
            AssertEquals("I see blue mountains and blue dogs".RemoveWord("blue", 2), "I see mountains and dogs");
            AssertEquals("I see blue mountains and blue dogs".RemoveWord("blue", 0), "I see mountains and dogs");
            AssertEquals("I see blue, everywhere".RemoveWord("blue", 0), "I see, everywhere");
            AssertEquals("I see, blue everywhere".RemoveWord("blue", 0), "I see, everywhere");
            AssertEquals("I see, blue, everywhere".RemoveWord("blue", 0), "I see, everywhere");
            AssertEquals("I see, BLUE, everywhere".RemoveWord("blue", 0), "I see, everywhere");

            //Remove words by position
            AssertEquals("I see rose everywhere.".RemoveWord(3, true), "I see rose.");
            AssertEquals("I see rose, everywhere.".RemoveWord(3, false), "I see rose,");
            AssertEquals("I see rose everywhere.".RemoveWord(0, true), "see rose everywhere.");
            AssertEquals("I see rose everywhere.".RemoveWord(0, false), "see rose everywhere.");
        }

        private static void TestInsensitiveReplaceToLower()
        {
            AssertEquals("I like musIc".ReplaceWordInsensitiveLower("music", "FooD"), "i like food");
            AssertEquals("Better is better".ReplaceWordKeepCase("better", "worse"), "Worse is worse");
            AssertEquals("You think YOU are the one, do you?".ReplaceWordKeepCase("you", "vous"), "Vous think VOUS are the one, do vous?");
        }

        private static void TestLinguisticsAnalysis()
        {
            TestCountWords();
            TestIsQuestion();
        }

        private static void TestIsQuestion()
        {
            AssertEquals("You like music?".IsQuestion(), true);
            AssertEquals("You like music".IsQuestion(), false);
            AssertEquals("Do you like music?".IsQuestion(), true);
            AssertEquals("Do you like music".IsQuestion(), true);
            AssertEquals("What do you like".IsQuestion(), true);
            AssertEquals("What are you doing".IsQuestion(), true);
            AssertEquals("What do you like?".IsQuestion(), true);
            AssertEquals("What are you doing?".IsQuestion(), true);
            AssertEquals("When are you going".IsQuestion(), true);
            AssertEquals("You like what?".IsQuestion(), true);
            AssertEquals("You like what".IsQuestion(), true);
            AssertEquals("say what?".IsQuestion(), true);
            AssertEquals("say what".IsQuestion(), true);
            AssertEquals("which one you choose?".IsQuestion(), true);
            AssertEquals("which one you choose".IsQuestion(), true);
            AssertEquals("I'm the one which is the best".IsQuestion(), false);
            AssertEquals("I'm the one who is the best".IsQuestion(), false);
            AssertEquals("How are you doing?".IsQuestion(), true);
            AssertEquals("How are you doing".IsQuestion(), true);
            AssertEquals("How do you do?".IsQuestion(), true);
            AssertEquals("This is how we do it".IsQuestion(), false);
            AssertEquals("Is this how we do it?".IsQuestion(), true);
            AssertEquals("Are you a retard?".IsQuestion(), true);
            AssertEquals("Are you a retard".IsQuestion(), true);
            AssertEquals("Is this a retard?".IsQuestion(), true);
            AssertEquals("Is this a retard".IsQuestion(), true);
            AssertEquals("This is a retard".IsQuestion(), false);
            AssertEquals("This is a retard?".IsQuestion(), true);
            AssertEquals("Is it ok?".IsQuestion(), true);
            AssertEquals("Is it ok".IsQuestion(), true);
            AssertEquals("Are you ok?".IsQuestion(), true);
            AssertEquals("Are you ok".IsQuestion(), true);
            AssertEquals("This is ok".IsQuestion(), false);
            AssertEquals("You are ok".IsQuestion(), false);
            AssertEquals("When do you come?".IsQuestion(), true);
            AssertEquals("When do you come".IsQuestion(), true);
            AssertEquals("Who are you?".IsQuestion(), true);
            AssertEquals("Who are you".IsQuestion(), true);
            AssertEquals("This is who you are".IsQuestion(), false);
            AssertEquals("This is who you are".IsQuestion(), false);
            AssertEquals("Whose planet is it?".IsQuestion(), true);
            AssertEquals("Whom Do We Remember?".IsQuestion(), true);
            AssertEquals("Whom Do We Remember".IsQuestion(), true);
            AssertEquals("Where do you live?".IsQuestion(), true);
            AssertEquals("Where do you live".IsQuestion(), true);
            AssertEquals("This is where I go".IsQuestion(), false);
            AssertEquals("I will tell you when".IsQuestion(), false);
            AssertEquals("I will tell you why".IsQuestion(), false);
            AssertEquals("Would you fuck a dog?".IsQuestion(), true);
            AssertEquals("Would you fuck a dog".IsQuestion(), true);
            AssertEquals("You would fuck a dog".IsQuestion(), false);
            AssertEquals("Can't you hear?".IsQuestion(), true);
            AssertEquals("Can't you hear".IsQuestion(), true);
            AssertEquals("You can hear".IsQuestion(), false);
            AssertEquals("You can't hear".IsQuestion(), false);
        }

        private static void AssertEquals(bool bool1, bool bool2)
        {
            if (bool1 != bool2)
                throw new Exception("Both should be true or false");
        }

        private static void TestLinguisticsTransformations()
        {
            TestInvertFirstSecondPerson();
            TestInvertNegation();
            TestSynonyms();
            TestAntonyms();
            TestInvertQuestion();
        }

        private static void TestInvertQuestion()
        {
            AssertEquals("You like music?".InvertQuestion(), "You like music");
            AssertEquals("Do you like music?".InvertQuestion(), "you like music");
            AssertEquals("Do you like music".InvertQuestion(), "you like music");
            AssertEquals("Does Mitchel like music?".InvertQuestion(), "Mitchel does like music");
            AssertEquals("Do I like music?".InvertQuestion(), "I like music");
            AssertEquals("What do you like".InvertQuestion(), "you like");
            AssertEquals("What are you doing".InvertQuestion(), "you are doing");
            AssertEquals("What do you like?".InvertQuestion(), "you like");
            AssertEquals("What are you doing?".InvertQuestion(), "you are doing");
            AssertEquals("When are you going".InvertQuestion(), "you are going");
            AssertEquals("You like what?".InvertQuestion(), "You like");
            AssertEquals("You like what".InvertQuestion(), "You like");
            AssertEquals("say what?".InvertQuestion(), "say");
            AssertEquals("say what".InvertQuestion(), "say");
            AssertEquals("How are you doing?".InvertQuestion(), "you are doing");
            AssertEquals("How are you doing".InvertQuestion(), "you are doing");
            AssertEquals("How do you do?".InvertQuestion(), "you");
            AssertEquals("Are you a retard?".InvertQuestion(), "you are a retard");
            AssertEquals("Are you a retard".InvertQuestion(), "you are a retard");
            AssertEquals("Is it ok?".InvertQuestion(), "it is ok");
            AssertEquals("Is it ok".InvertQuestion(), "it is ok");
            AssertEquals("Are you ok?".InvertQuestion(), "you are ok");
            AssertEquals("Are you ok".InvertQuestion(), "you are ok");
            AssertEquals("When do you come?".InvertQuestion(), "you come");
            AssertEquals("When do you come".InvertQuestion(), "you come");
            AssertEquals("When do you come to my house".InvertQuestion(), "you come to my house");
            AssertEquals("Who are you?".InvertQuestion(), "you are");
            AssertEquals("Who are you".InvertQuestion(), "you are");
            AssertEquals("Whom Do We Remember?".InvertQuestion(), "We Remember");
            AssertEquals("Whom Do We Remember".InvertQuestion(), "We Remember");
            AssertEquals("Where do you live?".InvertQuestion(), "you live");
            AssertEquals("Where do you live".InvertQuestion(), "you live");
            AssertEquals("Would you fuck a dog?".InvertQuestion(), "you would fuck a dog");
            AssertEquals("Would you fuck a dog".InvertQuestion(), "you would fuck a dog");
            AssertEquals("Can't you hear?".InvertQuestion(), "you can't hear");
            AssertEquals("Can't you hear".InvertQuestion(), "you can't hear");
            AssertEquals("Is this a retard?".InvertQuestion(), "this is a retard");
            AssertEquals("Is this a retard".InvertQuestion(), "this is a retard");
            AssertEquals("You would fuck a dog".InvertQuestion(), "would you fuck a dog?");
            AssertEquals("You can hear".InvertQuestion(), "can you hear?");
            AssertEquals("You can't hear".InvertQuestion(), "can't you hear?");
            AssertEquals("This is ok".InvertQuestion(), "is this ok?");
            AssertEquals("You are ok".InvertQuestion(), "are you ok?");
            AssertEquals("This is who you are".InvertQuestion(), "is this who you are?");
            AssertEquals("You like music".InvertQuestion(), "Do you like music?");
            AssertEquals("Mitchel likes music".InvertQuestion(), "Do you think Mitchel likes music?");
            AssertEquals("I'm the one which is the best".InvertQuestion(), "Do you think I'm the one which is the best?");
            AssertEquals("I'm the one who is the best".InvertQuestion(), "Do you think I'm the one who is the best?");
            AssertEquals("This is how we do it".InvertQuestion(), "is this how we do it?");
            AssertEquals("This is a retard".InvertQuestion(), "is this a retard?");
            AssertEquals("This is a retard?".InvertQuestion(), "This is a retard");
            AssertEquals("This is where I go".InvertQuestion(), "is this where I go?");
            AssertEquals("I will tell you when".InvertQuestion(), "will I tell you when?");
            AssertEquals("I will tell you why".InvertQuestion(), "will I tell you why?");

            AssertEquals("Whose planet is it?".InvertQuestion(), "This planet belongs to");
            AssertEquals("Is this how we do it?".InvertQuestion(), "this is how we do it");
            AssertEquals("which one do you choose?".InvertQuestion(), "you choose");
            AssertEquals("which one do you choose".InvertQuestion(), "you choose");
            AssertEquals("which one you choose?".InvertQuestion(), "you choose");
            AssertEquals("which one you choose".InvertQuestion(), "you choose");
        }

        private static void TestSynonyms()
        {
            AssertEquals("cool".TryFindBestSynonym(), "chill");
        }

        private static void TestAntonyms()
        {
            AssertEquals("big".TryFindBestAntonym(),"atomic");
        }

        private static void TestInvertNegation()
        {
            AssertEquals(Transformations.InvertNegation("I am nOt watching you"), "I am watching you");
            AssertEquals(Transformations.InvertNegation("I am watching you"), "I am not watching you");

            AssertEquals(Transformations.InvertNegation("I watch you"), "I don't watch you");
            AssertEquals(Transformations.InvertNegation("I DoN't watch you"), "I Do watch you");

            AssertEquals(Transformations.InvertNegation("I do Not watch you"), "I do watch you");
            AssertEquals(Transformations.InvertNegation("I do watch you"), "I don't watch you");

            AssertEquals(Transformations.InvertNegation("I wON't watch you"), "I wILL watch you");
            AssertEquals(Transformations.InvertNegation("I Will watch you"), "I won't watch you");

            AssertEquals(Transformations.InvertNegation("I will nOT watch you"), "I will watch you");

            AssertEquals(Transformations.InvertNegation("You AIN'T a dancer"), "You are a dancer");
            AssertEquals(Transformations.InvertNegation("You AIN'T no dancer"), "You are a dancer");

            AssertEquals(Transformations.InvertNegation("You ain't a dancer"), "You are a dancer");
            AssertEquals(Transformations.InvertNegation("You ain't no dancer"), "You are a dancer");

            AssertEquals(Transformations.InvertNegation("You are fofdghdsting your homework"), "You are not fofdghdsting your homework");
            AssertEquals(Transformations.InvertNegation("You are not fofdghdsting your homework"), "You are fofdghdsting your homework");

            AssertEquals(Transformations.InvertNegation("fhh fdgfdghdsaf"), "It's not like fhh fdgfdghdsaf");
            AssertEquals(Transformations.InvertNegation("Fhh fdgfdghdsaf"), "It's not like Fhh fdgfdghdsaf");

            AssertEquals(Transformations.InvertNegation("I love you"), "I don't love you");
            AssertEquals(Transformations.InvertNegation("I don't love you"), "I do love you");

            AssertEquals(Transformations.InvertNegation("This is not hot"), "This is hot");
            AssertEquals(Transformations.InvertNegation("This is hot"), "This is not hot");
        }

        private static void TestInvertFirstSecondPerson()
        {
            AssertEquals(Transformations.InvertFirstSecondPerson("I love you"), "You love me");
            AssertEquals(Transformations.InvertFirstSecondPerson("You love me"), "I love you");

            AssertEquals(Transformations.InvertFirstSecondPerson("I listen to you"), "You listen to me");
            AssertEquals(Transformations.InvertFirstSecondPerson("You listen to me"), "I listen to you");

            AssertEquals(Transformations.InvertFirstSecondPerson("This is my hat"), "This is your hat");
            AssertEquals(Transformations.InvertFirstSecondPerson("This is your hat"), "This is my hat");

            AssertEquals(Transformations.InvertFirstSecondPerson("I'm the best, yes, I'm the best"), "You're the best, yes, you're the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You're the best, yes, you're the best"), "I'm the best, yes, I'm the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("I am the best"), "You are the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You are the best"), "I am the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("I am the best, yes, I am the best"), "You are the best, yes, you are the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You are the best, yes, you are the best"), "I am the best, yes, I am the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("I was the best"), "You were the best");
            AssertEquals(Transformations.InvertFirstSecondPerson("You were the best"), "I was the best");

            AssertEquals(Transformations.InvertFirstSecondPerson("You will be rewarded"), "I will be rewarded");
            AssertEquals(Transformations.InvertFirstSecondPerson("I will be rewarded"), "You will be rewarded");

            AssertEquals(Transformations.InvertFirstSecondPerson("You'll be rewarded"), "I'll be rewarded");
            AssertEquals(Transformations.InvertFirstSecondPerson("I'll be rewarded"), "You'll be rewarded");

            AssertEquals(Transformations.InvertFirstSecondPerson("This hat is yours"), "This hat is mine");
            AssertEquals(Transformations.InvertFirstSecondPerson("This hat is mine"), "This hat is yours");

            AssertEquals(Transformations.InvertFirstSecondPerson("You will do it by yourself"), "I will do it by myself");
            AssertEquals(Transformations.InvertFirstSecondPerson("I will do it by myself"), "You will do it by yourself");

            AssertEquals(Transformations.InvertFirstSecondPerson("Do you think I should go there?"), "Do I think you should go there?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Do I think you should go there?"), "Do you think I should go there?");

            AssertEquals(Transformations.InvertFirstSecondPerson("Do you wish you were god?"), "Do I wish I was god?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Do I wish I was god?"), "Do you wish you were god?");

            AssertEquals(Transformations.InvertFirstSecondPerson("You and me, baby ain't nothing but mammals"), "I and you, baby ain't nothing but mammals");
            AssertEquals(Transformations.InvertFirstSecondPerson("I and you, baby ain't nothing but mammals"), "You and me, baby ain't nothing but mammals");

            AssertEquals(Transformations.InvertFirstSecondPerson("it's about you."), "it's about me.");
            AssertEquals(Transformations.InvertFirstSecondPerson("it's about me."), "it's about you.");

            AssertEquals(Transformations.InvertFirstSecondPerson("You'd be surprised to see how much I care about you."), "I'd be surprised to see how much you care about me.");
            AssertEquals(Transformations.InvertFirstSecondPerson("I'd be surprised to see how much you care about me."), "You'd be surprised to see how much I care about you.");

            AssertEquals(Transformations.InvertFirstSecondPerson("There's nothing I could say to you"), "There's nothing you could say to me");
            AssertEquals(Transformations.InvertFirstSecondPerson("There's nothing you could say to me"), "There's nothing I could say to you");

            AssertEquals(Transformations.InvertFirstSecondPerson("There's nothing I could say to you."), "There's nothing you could say to me.");
            AssertEquals(Transformations.InvertFirstSecondPerson("There's nothing you could say to me."), "There's nothing I could say to you.");

            AssertEquals(Transformations.InvertFirstSecondPerson("What would you do if you were God? Would you bless me?"), "What would I do if I was God? Would I bless you?");
            AssertEquals(Transformations.InvertFirstSecondPerson("What would I do if I was God? Would I bless you?"), "What would you do if you were God? Would you bless me?");

            AssertEquals(Transformations.InvertFirstSecondPerson("Why do you laugh at me like that?"), "Why do I laugh at you like that?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Why do I laugh at you like that?"), "Why do you laugh at me like that?");

            AssertEquals(Transformations.InvertFirstSecondPerson("Do you think I will be saved?"), "Do I think you will be saved?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Do I think you will be saved?"), "Do you think I will be saved?");

            AssertEquals(Transformations.InvertFirstSecondPerson("Do you think I am stupid?"), "Do I think you are stupid?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Do I think you are stupid?"), "Do you think I am stupid?");

            AssertEquals(Transformations.InvertFirstSecondPerson("Why do you poke? I like that?"), "Why do I poke? You like that?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Why do I poke? You like that?"), "Why do you poke? I like that?");

            AssertEquals(Transformations.InvertFirstSecondPerson("I'm looking at you were dumb"), "You're looking at me was dumb");
            AssertEquals(Transformations.InvertFirstSecondPerson("You're looking at me was dumb"), "I'm looking at you were dumb");

            AssertEquals(Transformations.InvertFirstSecondPerson("Why do you poke me like that?"), "Why do I poke you like that?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Why do I poke you like that?"), "Why do you poke me like that?");

            AssertEquals(Transformations.InvertFirstSecondPerson("You turn me on!"), "I turn you on!");
            AssertEquals(Transformations.InvertFirstSecondPerson("I turn you on!"), "You turn me on!");

            AssertEquals(Transformations.InvertFirstSecondPerson("You tjkghkgsdurn me on!"), "I tjkghkgsdurn you on!");
            AssertEquals(Transformations.InvertFirstSecondPerson("I tjkghkgsdurn you on!"), "You tjkghkgsdurn me on!");

            AssertEquals(Transformations.InvertFirstSecondPerson("Where did you go?"), "Where did I go?");
            AssertEquals(Transformations.InvertFirstSecondPerson("Where did I go?"), "Where did you go?");

            AssertEquals(Transformations.InvertFirstSecondPerson("somewhere I belong"), "somewhere you belong");
            AssertEquals(Transformations.InvertFirstSecondPerson("somewhere you belong"), "somewhere I belong");

            AssertEquals(Transformations.InvertFirstSecondPerson("where I belong"), "where you belong");
            AssertEquals(Transformations.InvertFirstSecondPerson("where you belong"), "where I belong");

            AssertEquals(Transformations.InvertFirstSecondPerson("when I come around"), "when you come around");
            AssertEquals(Transformations.InvertFirstSecondPerson("when you come around"), "when I come around");

            AssertEquals(Transformations.InvertFirstSecondPerson("where I fdhsdaytr"), "where you fdhsdaytr");
            AssertEquals(Transformations.InvertFirstSecondPerson("where you fdhsdaytr"), "where I fdhsdaytr");

            AssertEquals(Transformations.InvertFirstSecondPerson("when I fdhsdaytr around"), "when you fdhsdaytr around");
            AssertEquals(Transformations.InvertFirstSecondPerson("when you fdhsdaytr around"), "when I fdhsdaytr around");

            AssertEquals(Transformations.InvertFirstSecondPerson("somewhere I fdhsdaytr"), "somewhere you fdhsdaytr");
            AssertEquals(Transformations.InvertFirstSecondPerson("somewhere you fdhsdaytr"), "somewhere I fdhsdaytr");

            AssertEquals(Transformations.InvertFirstSecondPerson("you are listening while I talk"), "I am listening while you talk");
            AssertEquals(Transformations.InvertFirstSecondPerson("I am listening while you talk"), "You are listening while I talk");

            AssertEquals(Transformations.InvertFirstSecondPerson("you are listening while I tasdfssdlk"), "I am listening while you tasdfssdlk");
            AssertEquals(Transformations.InvertFirstSecondPerson("I am listening while you tasdfssdlk"), "You are listening while I tasdfssdlk");
        }

        private static void AssertEquals(string string1, string string2)
        {
            if (string1 != string2)
                throw new Exception("Wrong value: "+string1 +" should be: "+string2);
        }

        private static void AssertEquals(int int1, int int2)
        {
            if (int1 != int2)
                throw new Exception("Wrong value: " + int1 + " should be: " + int2);
        }
        #endregion
    }
}
