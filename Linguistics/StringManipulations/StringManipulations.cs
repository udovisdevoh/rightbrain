using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Linguistics
{
    /// <summary>
    /// Used for generic string manipulations
    /// </summary>
    static class StringManipulations
    {
        #region Parts
        /// <summary>
        /// Used to replace word in string while keeping original case structure
        /// </summary>
        private static KeepCaseReplacer keepCaseReplacer = new KeepCaseReplacer();

        /// <summary>
        /// List of possible word delimiters
        /// </summary>
        private static char[] wordDelimiterList = { ' ', '\n', '\r', '.', ',', ')', '(','"','{','}','[',']',':',';','?','%','!' };
        #endregion

        #region Public Methods
        /// <summary>
        /// Replace content in string but keep original case
        /// </summary>
        /// <param name="original">original</param>
        /// <param name="from">to replace</param>
        /// <param name="to">to replace to</param>
        /// <returns>String with replaced content with case kept</returns>
        public static string ReplaceWordKeepCase(this string original, string from, string to)
        {
            return keepCaseReplacer.ReplaceWord(original, from, to);
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Take a string and apply another string's case structure
        /// </summary>
        /// <param name="target">string to modify</param>
        /// <param name="source">string to take case structure from</param>
        /// <returns>String with modified case structure</returns>
        internal static string ApplyWordCaseStructure(this string target, string source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert string to all lowercase and replace word from to
        /// </summary>
        /// <param name="original">original string</param>
        /// <param name="from">from word</param>
        /// <param name="to">to word</param>
        /// <returns>lowcase string with replaced words</returns>
        internal static string ReplaceWordInsensitiveLower(this string original, string from, string to)
        {
            original = original.ToLower();
            from = from.ToLower();
            to = to.ToLower();

            string newString = " " + original + " ";

            foreach (char wordDelimiter1 in wordDelimiterList)
                foreach (char wordDelimiter2 in wordDelimiterList)
                    newString = newString.Replace(wordDelimiter1 + from + wordDelimiter2, wordDelimiter1 + to + wordDelimiter2);       

            newString = newString.Substring(1, newString.Length - 2);

            return newString;
        }
        #endregion
    }
}