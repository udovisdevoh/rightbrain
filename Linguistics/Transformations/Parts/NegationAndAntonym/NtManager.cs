using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages words like "don't" and "didn't" and "doesn't"
    /// </summary>
    internal class NtManager
    {
        #region Internal Methods
        /// <summary>
        /// Remove words like "don't" and "didn't" and "doesn't"
        /// </summary>
        /// <param name="originalText">original text</param>
        /// <returns>original text with removed occurence of don't, didn't or doesn't</returns>
        internal string RemoveNt(string originalText)
        {
            return RemoveNt(originalText, 0);
        }

        /// <summary>
        /// Remove words like "don't" and "didn't" and "doesn't"
        /// </summary>
        /// <param name="originalText">original text</param>
        /// <param name="desiredRemoveCount">how many times we remove it (default: 0 as infinite)</param>
        /// <returns>original text with removed occurence of don't, didn't or doesn't</returns>
        internal string RemoveNt(string originalText, int desiredRemoveCount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}