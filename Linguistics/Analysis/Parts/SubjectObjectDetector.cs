using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages the difference between subjects and objects
    /// </summary>
    internal class SubjectObjectDetector
    {
        /// <summary>
        /// Whether word is a subject and not an object according to provided context
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is a subject and not an object according to provided context</returns>
        internal bool IsSubjectNotObject(Word word)
        {
            if (word.IsSentenceBegin)
                return true;

            if (word.PreviousWord == null)
                return true;

            if (word.NextWord == null)
                return false;

            if (word.LeftDelimiter == null)
                return true;

            if (word.RightDelimiter == null)
                return false;

            string previousWord = word.PreviousWord.ToString().ToLower();
            string nextWord = word.NextWord.ToString().ToLower();

            if (word.LeftDelimiter.Contains(','))
                return true;

            if (word.RightDelimiter.Contains(','))
                return false;

            if (previousWord == "do" && nextWord == "a")
                return false;

            if (previousWord == "do" && nextWord == "an")
                return false;

            if (previousWord == "do")
                return true;

            if (previousWord == "to")
                return false;

            if (previousWord == "at")
                return false;

            if (previousWord == "on")
                return false;


            bool isNextWordVerb = Analysis.IsVerb(nextWord);
            bool isPreviousWordVerb = Analysis.IsVerb(previousWord);


            if (isPreviousWordVerb && Analysis.IsPreposition(nextWord))
                return false;

            if (Analysis.IsPostposition(nextWord))
                return false;

            if (isNextWordVerb)
                return true;

            if (isPreviousWordVerb)
                return false;

            return false;
        }
    }
}
