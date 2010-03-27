using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages questions that are questions because they end with a special word for questions
    /// </summary>
    internal class QuestionManagerByEndingWord
    {
        /// <summary>
        /// Whether question was detected because of the ending word
        /// </summary>
        /// <param name="originalProposition">proposition</param>
        /// <returns>Whether question was detected because of the ending word</returns>
        internal bool IsQuestion(string originalProposition)
        {
            WordStringStream wordStringStream = new WordStringStream(originalProposition);
            return wordStringStream.Last().IsQuestionEndingWord();
        }
    }
}
