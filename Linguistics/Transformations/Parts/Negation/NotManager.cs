using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages operations on the word "not"
    /// </summary>
    internal class NotManager
    {
        #region Parts
        /// <summary>
        /// List of words that can be followed by "not"
        /// </summary>
        private WordListFromFile wordToPutNotAfterList = new WordListFromFile("Linguistics/WordLists/wordToPutNotAfterList.txt");
        #endregion

        #region Internal Methods
        /// <summary>
        /// Add word "not" before first word ending with "ing" or "in'"
        /// </summary>
        /// <param name="text">text to modify</param>
        /// <returns>text with added "not" before first word wnding with ing or in'</returns>
        internal string AddNotBeforeFirstWordEndingWithIng(string text)
        {
            WordStringStream wordStringStream = new WordStringStream(text);
            string newString = wordStringStream.FirstDelimiter;

            bool alreadyDid = false;

            string currentWord, currentDelimiter;
            while (wordStringStream.TryGetNextWord(out currentWord, out currentDelimiter))
            {
                if (!alreadyDid && (currentWord.ToLower().EndsWith("ing") || currentWord.ToLower().EndsWith("in'")))
                {
                    currentWord = "not " + currentWord;
                    alreadyDid = true;
                }

                newString += currentWord;

                if (currentDelimiter != null)
                    newString += currentDelimiter;
            }

            return newString;
        }

        /// <summary>
        /// Whether there is a word that can be followed by "not" in original proposition
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether there is a word that can be followed by "not" in original proposition</returns>
        internal bool ContaisnWordToPutNotAfter(string originalProposition)
        {
            foreach (string word in new WordStringStream(originalProposition))
                if (wordToPutNotAfterList.ContainsExact(word.ToLower()))
                    return true;

            return false;
        }

        internal string AddNotAfterFirstWordForIt(string originalProposition)
        {
            WordStringStream wordStringStream = new WordStringStream(originalProposition);
            string newString = wordStringStream.FirstDelimiter;

            bool alreadyDid = false;

            string currentWord, currentDelimiter;
            while (wordStringStream.TryGetNextWord(out currentWord, out currentDelimiter))
            {
                if (!alreadyDid && wordToPutNotAfterList.ContainsExact(currentWord.ToLower()))
                {
                    currentWord = currentWord + " not";
                    alreadyDid = true;
                }

                newString += currentWord;

                if (currentDelimiter != null)
                    newString += currentDelimiter;
            }

            return newString;
        }
        #endregion
    }
}
