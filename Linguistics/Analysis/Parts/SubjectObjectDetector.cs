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
        #region Constants
        /// <summary>
        /// When it is a subject
        /// </summary>
        private const bool isSubject = true;

        /// <summary>
        /// When it is an object
        /// </summary>
        private const bool isObject = false;
        #endregion

        #region Public Methods
        /// <summary>
        /// Whether word is a subject and not an object according to provided context
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is a subject and not an object according to provided context</returns>
        internal bool IsSubjectNotObject(Word word)
        {
            if (word.IsSentenceBegin)
                return isSubject;

            if (word.PreviousWord == null)
                return isSubject;

            if (word.NextWord == null)
                return isObject;

            if (word.LeftDelimiter == null)
                return isSubject;

            if (word.RightDelimiter == null)
                return isObject;

            string previousWord = word.PreviousWord.ToString().ToLower();
            string nextWord = word.NextWord.ToString().ToLower();

            if (word.LeftDelimiter.Contains(','))
                return isSubject;

            if (word.RightDelimiter.Contains(','))
                return isObject;

            if (previousWord == "do" && nextWord == "a")
                return isObject;

            if (previousWord == "do" && nextWord == "an")
                return isObject;

            if (previousWord == "do")
                return isSubject;

            if (previousWord == "to")
                return isObject;

            if (previousWord == "at")
                return isObject;

            if (previousWord == "on")
                return isObject;


            bool isNextWordVerb = Analysis.IsVerb(nextWord);
            bool isPreviousWordVerb = Analysis.IsVerb(previousWord);


            if (isPreviousWordVerb && Analysis.IsPreposition(nextWord))
                return isObject;

            if (Analysis.IsPostposition(nextWord))
                return isObject;

            if (Analysis.IsQuestionBeginWord(previousWord) || previousWord.StartsWith("some") && Analysis.IsQuestionBeginWord(previousWord.Substring(4)))
                return isSubject;

            if (isNextWordVerb)
                return isSubject;

            if (isPreviousWordVerb)
                return isObject;

            return isObject;
        }
        #endregion
    }
}
