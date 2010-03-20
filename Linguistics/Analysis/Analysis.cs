using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// For linguistic and semantical analysis
    /// </summary>
    public static class Analysis
    {
        #region Parts
        /// <summary>
        /// Manages analysis of verbs
        /// </summary>
        private static VerbManager verbManager = new VerbManager();
        #endregion

        #region Public Methods
        /// <summary>
        /// Whether the word is a verb
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is a verb</returns>
        public static bool IsVerb(string word)
        {
            return verbManager.IsVerb(word);
        }
        #endregion
    }
}
