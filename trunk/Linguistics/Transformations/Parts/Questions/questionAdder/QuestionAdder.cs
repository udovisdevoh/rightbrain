using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Converts affirmations to questions
    /// </summary>
    internal class QuestionAdder
    {
        #region Internal Methods
        /// <summary>
        /// Convert proposition to question
        /// </summary>
        /// <param name="proposition">proposition</param>
        /// <returns>proposition as question</returns>
        internal string AddQuestion(string proposition)
        {
            WordStream wordStream = new WordStream(proposition);

            //Invert first word with second if second word is a question word or a modal verb
            if (wordStream.CountWords() > 1 && wordStream[1].StringValue.ToLower().IsQuestionBeginWord() || wordStream[1].StringValue.ToLower().IsModalVerb())
            {
                Word firstWord = wordStream[0];

                if (firstWord.StringValue.IsPronoun() && firstWord.StringValue.ToLower() != "i")
                {
                    firstWord.StringValue = firstWord.StringValue.ToLower();
                    proposition = wordStream.ToString();
                }

                proposition = proposition.InvertWordPosition(0, 1);
            }

            proposition = AddQuestionMark(proposition);

            return proposition;

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Add question mark to proposition
        /// </summary>
        /// <param name="proposition">proposition</param>
        /// <returns>proposition with question mark</returns>
        private string AddQuestionMark(string proposition)
        {
            WordStream wordStream = new WordStream(proposition);
            Word lastWord = wordStream.Last();
            lastWord.RightDelimiter = "?";
            return wordStream.ToString();
        }
        #endregion
    }
}
