using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages operations and analysis on questions
    /// </summary>
    internal class QuestionManager
    {
        #region Parts
        /// <summary>
        /// Manages questions that are questions just because they contain ? for they wouldn't be questions otherwise
        /// </summary>
        private QuestionManagerByMarkOnly questionManagerByMarkOnly = new QuestionManagerByMarkOnly();

        /// <summary>
        /// Manages questions that are questions because they start with question starting words
        /// </summary>
        private QuestionManagerByStartingWithQuestionWord questionManagerByStartingWithQuestionWord = new QuestionManagerByStartingWithQuestionWord();

        /// <summary>
        /// Manages questions that are questions because they end with a special word for questions
        /// </summary>
        private QuestionManagerByEndingWord questionManagerByEndingWord = new QuestionManagerByEndingWord();

        /// <summary>
        /// Manages questions that are questions because they begin with modal verbs
        /// </summary>
        private QuestionManagerByModalVerb questionManagerByModalVerb = new QuestionManagerByModalVerb();
        #endregion

        #region Internal Methods
        /// <summary>
        /// Whether provied proposition is question or not
        /// </summary>
        /// <param name="originalProposition">provided proposition</param>
        /// <returns>Whether provied proposition is question or not</returns>
        internal bool IsQuestion(string originalProposition)
        {
            originalProposition = originalProposition.ToLower();

            if (questionManagerByStartingWithQuestionWord.IsQuestion(originalProposition))
                return true;
            else if (questionManagerByModalVerb.IsQuestion(originalProposition))
                return true;
            else if (questionManagerByEndingWord.IsQuestion(originalProposition))
                return true;
            else if (questionManagerByMarkOnly.IsQuestion(originalProposition))
                return true;

            return false;
        }
        #endregion
    }
}
