using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages words such as you, me, I, yours mine, my, mines etc...
    /// </summary>
    internal class FirstSecondPersonManager
    {
        #region Internal Methods
        /// <summary>
        /// Invert "YOU" and "I" from string (your and my etc...)
        /// </summary>
        /// <param name="originalText">original text</param>
        /// <returns>Text with YOU and I inverted (your and my etc...)</returns>
        internal string InvertFirstSecondPerson(string originalText)
        {
            originalText = originalText.InvertWordKeepCase("my", "your");
            originalText = originalText.InvertWordKeepCase("i'm", "you're");
            originalText = originalText.InvertWordKeepCase("am", "are");
            originalText = originalText.InvertWordKeepCase("was", "were");
            originalText = originalText.InvertWordKeepCase("mine", "yours");
            originalText = originalText.InvertWordKeepCase("myself", "yourself");


            WordStream wordStream = new WordStream(originalText);

            string newString = wordStream.FirstDelimiter;
            string originalWord;
            string currentDelimiter;
            string newWord;
            string previousWord = null;
            bool isSentenceBegin;

            while (wordStream.TryGetNextWord(out originalWord, out currentDelimiter, out isSentenceBegin))
            {
                newWord = originalWord.ReplaceWordKeepCase("i", "me");

                if (newWord == "ME")
                    newWord = "me";

                newWord = newWord.InvertWordKeepCase("you", "me");

                if (newWord.ToLower() == "me" && isSentenceBegin)
                    newWord = "I";

                if (newWord == "i")
                    newWord = "I";

                if (newWord == "i'm")
                    newWord = "I'm";

                if (newWord == "YOu" && !isSentenceBegin)
                    newWord = "you";

                if (newWord == "YOu're")
                    newWord = "You're";

                if (newWord == "You" && !isSentenceBegin)
                    newWord = "you";

                if (newWord == "You're" && !isSentenceBegin)
                    newWord = "you're";

                if (newWord == "You're" && !isSentenceBegin)
                    newWord = "you";

                if (newWord == "you" && isSentenceBegin)
                    newWord = "You";

                if (newWord == "YOu")
                    newWord = "You";

                newString += newWord;

                if (currentDelimiter != null)
                    newString += currentDelimiter;

                previousWord = newWord;
            }

            return newString;
        }
        #endregion
    }
}
