using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Used for linguistic transformations
    /// </summary>
    public static class Transformations
    {
        #region Parts
        /// <summary>
        /// Manages words such as you, me, I, yours mine, my, mines etc...
        /// </summary>
        private static FirstSecondPersonManager firstSecondPersonManager = new FirstSecondPersonManager();

        /// <summary>
        /// Performs negation of proposions
        /// </summary>
        private static NegationAndAntonymManager negationAndAntonymManager = new NegationAndAntonymManager();
        #endregion

        #region Public Methods
        /// <summary>
        /// Invert "YOU" and "I" from string (your and my etc...)
        /// </summary>
        /// <param name="originalText">original text</param>
        /// <returns>Text with YOU and I inverted (your and my etc...)</returns>
        public static string InvertFirstSecondPerson(string originalText)
        {
            return firstSecondPersonManager.InvertFirstSecondPerson(originalText);
        }

        /// <summary>
        /// Invert negation of proposition by removing or adding words like "not" or by replacing a word to an antonym
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Proposition with inverted negation or with antonyms</returns>
        public static string InvertNegation(string originalProposition)
        {
            return negationAndAntonymManager.InvertNegation(originalProposition);
        }
        #endregion
    }
}