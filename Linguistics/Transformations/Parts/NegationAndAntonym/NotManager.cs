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
        #endregion
    }
}
