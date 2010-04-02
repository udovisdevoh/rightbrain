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

        private QuestionAdder questionAdder = new QuestionAdder();
        #endregion

        #region Internal Methods
        /// <summary>
        /// Whether provied proposition is question or not
        /// </summary>
        /// <param name="originalProposition">provided proposition</param>
        /// <returns>Whether provied proposition is question or not</returns>
        internal bool IsQuestion(string originalProposition)
        {
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

        /// <summary>
        /// Convert original proposition to question if it's not and to affirmation or negation if it's a question
        /// </summary>
        /// <param name="proposition">original proposition</param>
        /// <returns>Converted original proposition to question if it wasn't and to affirmation or negation if was a question</returns>
        internal string InvertQuestion(string proposition)
        {
            if (IsQuestion(proposition))
            {
                proposition = proposition.Trim();

                if (proposition.ToLower().StartsWith("which one "))
                    proposition = proposition.Substring(9).Trim();
                else if (questionManagerByStartingWithQuestionWord.IsQuestion(proposition))
                    proposition = questionManagerByStartingWithQuestionWord.RemoveQuestion(proposition);
                else if (questionManagerByModalVerb.IsQuestion(proposition))
                    proposition = questionManagerByModalVerb.RemoveQuestion(proposition);
                else if (questionManagerByEndingWord.IsQuestion(proposition))
                    proposition = questionManagerByEndingWord.RemoveQuestion(proposition);

                if (IsSecondWordDo(proposition))
                    proposition = proposition.RemoveWord(1, false);
                else if (IsFirstWordDo(proposition))
                    proposition = proposition.RemoveWord(0, false);

                proposition = questionManagerByMarkOnly.RemoveQuestion(proposition);
            }
            else
            {
                proposition = questionAdder.AddQuestion(proposition);
            }

            return proposition;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Whether 1st word is "do"
        /// </summary>
        /// <param name="proposition">proposition</param>
        /// <returns>Whether 1st word is "do"</returns>
        private bool IsFirstWordDo(string proposition)
        {
            WordStream wordStream = new WordStream(proposition);
            return wordStream.CountWords() > 0 && wordStream[0].ToString().ToLower() == "do";
        }

        /// <summary>
        /// Whether 2nd word is "do"
        /// </summary>
        /// <param name="proposition">proposition</param>
        /// <returns>Whether 2nd word is "do"</returns>
        private bool IsSecondWordDo(string proposition)
        {
            WordStream wordStream = new WordStream(proposition);
            return wordStream.CountWords() > 1 && wordStream[1].ToString().ToLower() == "do";
        }
        #endregion
    }
}
