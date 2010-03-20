using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages the difference between I and ME words
    /// </summary>
    internal class FirstPersonManager
    {
        #region Internal Methods
        /// <summary>
        /// Returns word "you" or "i" depending on the context.
        /// </summary>
        /// <param name="previousDelimiter">previous delimiter (can be null)</param>
        /// <param name="previousWord">previous word (can be null)</param>
        /// <param name="nextWord">next word (can be null)</param>
        /// <param name="isSentenceBegin">whether the word is at the begining of a sentence</param>
        /// <returns></returns>
        internal string GetFirstPersonWord(string previousDelimiter, string previousWord, string nextWord, bool isSentenceBegin)
        {
            if (isSentenceBegin)
                return "i";

            if (previousWord == null)
                return "i";

            if (nextWord == null)
                return "me";

            if (previousDelimiter == null)
                return "i";

            previousWord = previousWord.ToLower();
            nextWord = nextWord.ToLower();

            if (previousDelimiter.Contains(','))
                return "i";

            if (previousWord == "do" && nextWord == "a")
                return "me";

            if (previousWord == "do" && nextWord == "an")
                return "me";

            if (previousWord == "do")
                return "i";

            if (Analysis.IsVerb(nextWord))
                return "i";

            return "me";
        }
        #endregion
    }
}
