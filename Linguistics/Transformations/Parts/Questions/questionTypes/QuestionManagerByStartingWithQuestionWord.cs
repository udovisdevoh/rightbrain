using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages questions that are questions because they start with question starting words
    /// </summary>
    internal class QuestionManagerByStartingWithQuestionWord
    {
        #region Internal Methods
        /// <summary>
        /// Whether proposition is detected to be a question because it starts with a question word
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether proposition is detected to be a question because it starts with a question word</returns>
        internal bool IsQuestion(string originalProposition)
        {
            foreach (string word in new WordStringStream(originalProposition))
                if (word.IsQuestionBeginWord())
                    return true;
            return false;
        }
        #endregion
    }
}
