using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages questions that are questions because they begin with modal verbs
    /// </summary>
    internal class QuestionManagerByModalVerb
    {
        /// <summary>
        /// Whether question was detected becayse proposition begins with modal verb
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether question was detected becayse proposition begins with modal verb</returns>
        internal bool IsQuestion(string originalProposition)
        {
            WordStringStream stream = new WordStringStream(originalProposition);
            return stream.First().IsModalVerb();
        }
    }
}
