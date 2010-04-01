﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages questions that are questions just because they contain ? for they wouldn't be questions otherwise
    /// </summary>
    internal class QuestionManagerByMarkOnly
    {
        #region Internal Methods
        /// <summary>
        /// Whether question was detected by ?
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether question was detected by ?</returns>
        internal bool IsQuestion(string originalProposition)
        {
            originalProposition = originalProposition.ToLower();
            return originalProposition.Contains('?');
        }

        /// <summary>
        /// Remove question mark
        /// </summary>
        /// <param name="originalProposition">originalProposition</param>
        /// <returns>proposition with question mark removed</returns>
        internal string RemoveQuestion(string originalProposition)
        {
            return originalProposition.Replace('?', '.');
        }
        #endregion
    }
}
