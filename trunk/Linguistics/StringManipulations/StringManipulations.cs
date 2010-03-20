﻿using System;
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
        private static readonly char[] wordDelimiterList = { ' ', '\n', '\r', '.', ',', ')', '(','"','{','}','[',']',':',';','?','%','!' };

        /// <summary>
        /// HashSet of possible word delimiters
        /// </summary>
        private static readonly HashSet<char> wordDelimiterHash;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialization of default data
        /// </summary>
        static StringManipulations()
        {
            wordDelimiterHash = new HashSet<char>(wordDelimiterList);
        }
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
        
        /// <summary>
        /// Whether a char is upperCase
        /// </summary>
        /// <param name="letter">char</param>
        /// <returns>Whether a char is upperCase</returns>
        public static bool IsUpperCase(this char letter)
        {
            return letter.ToString().ToUpper() == letter.ToString();
        }

        /// <summary>
        /// Convert a char to upperCase
        /// </summary>
        /// <param name="letter">char</param>
        /// <returns>UpperCase version of char</returns>
        public static char ToUpper(this char letter)
        {
            return letter.ToString().ToUpper()[0];
        }

        /// <summary>
        /// Convert a char to lowerCase
        /// </summary>
        /// <param name="letter">char</param>
        /// <returns>lowerCase version</returns>
        public static char ToLower(this char letter)
        {
            return letter.ToString().ToLower()[0];
        }
        #endregion

        #region Internal Methods
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

        /// <summary>
        /// Whether character is a word delimiter
        /// </summary>
        /// <param name="letter">character</param>
        /// <returns>Whether character is a word delimiter</returns>
        internal static bool IsWordDelimiter(char letter)
        {
            return wordDelimiterHash.Contains(letter);
        }
        #endregion
    }
}