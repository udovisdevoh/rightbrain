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
        /// Whether word should be "me" or "i" according to the context
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word should be "me" or "i" according to the context</returns>
        internal string GetFirstPersonWord(Word word)
        {
            if (word.IsSentenceBegin)
                return "i";

            if (word.PreviousWord == null)
                return "i";

            if (word.NextWord == null)
                return "me";

            if (word.LeftDelimiter == null)
                return "i";

            if (word.RightDelimiter == null)
                return "me";

            string previousWord = word.PreviousWord.ToString().ToLower();
            string nextWord = word.NextWord.ToString().ToLower();

            if (word.LeftDelimiter.Contains(','))
                return "i";

            if (word.RightDelimiter.Contains(','))
                return "me";

            if (previousWord == "do" && nextWord == "a")
                return "me";

            if (previousWord == "do" && nextWord == "an")
                return "me";

            if (previousWord == "do")
                return "i";

            if (previousWord == "to")
                return "me";

            if (previousWord == "at")
                return "me";

            if (previousWord == "on")
                return "me";


            bool isNextWordVerb = Analysis.IsVerb(nextWord);
            bool isPreviousWordVerb = Analysis.IsVerb(previousWord);

            
            if (isPreviousWordVerb && Analysis.IsPreposition(nextWord))
                return "me";

            if (Analysis.IsPostposition(nextWord))
                return "me";

            if (isNextWordVerb)
                return "i";

            if (isPreviousWordVerb)
                return "me";

            return "me";
        }
        #endregion
    }
}
