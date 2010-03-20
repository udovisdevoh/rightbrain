using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Replace words in string while keeping original case structure
    /// </summary>
    class KeepCaseReplacer
    {
        #region Internal Methods
        /// <summary>
        /// replace words in string while keeping original case structure
        /// </summary>
        /// <param name="original">original string</param>
        /// <param name="from">string to replace</param>
        /// <param name="to">replace to</param>
        /// <returns>String with replaced words with case structure kept</returns>
        internal string ReplaceWord(string original, string from, string to)
        {
            string newString = original.ReplaceWordInsensitiveLower(from, to);
            newString = newString.ApplyWordCaseStructure(original);
            return newString;
        }
        #endregion
    }
}
