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
        private static NegationManager negationAndAntonymManager = new NegationManager();

        /// <summary>
        /// Manages operations and analysys on synonyms and antonyms
        /// </summary>
        private static SynonymManager synonymManager = new SynonymManager();

        /// <summary>
        /// Manages operations and analysis on questions
        /// </summary>
        private static QuestionManager questionManager = new QuestionManager();
        #endregion

        #region Public Methods
        /// <summary>
        /// Invert "YOU" and "I" from string (your and my etc...)
        /// </summary>
        /// <param name="originalText">original text</param>
        /// <returns>Text with YOU and I inverted (your and my etc...)</returns>
        public static string InvertFirstSecondPerson(this string originalText)
        {
            return firstSecondPersonManager.InvertFirstSecondPerson(originalText);
        }

        /// <summary>
        /// Invert negation of proposition by removing or adding words like "not" or by replacing a word to an antonym
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Proposition with inverted negation or with antonyms</returns>
        public static string InvertNegation(this string originalProposition)
        {
            return negationAndAntonymManager.InvertNegation(originalProposition);
        }

        /// <summary>
        /// Try find best synonym for word or return null if none found
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>best synonym found for word or return null if none found</returns>
        public static string TryFindBestSynonym(this string word)
        {
            return synonymManager.TryFindBestSynonym(word);
        }

        /// <summary>
        /// Try find best antonym for word or return null if none found
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>best antonym found for word or return null if none found</returns>
        public static string TryFindBestAntonym(this string word)
        {
            return synonymManager.TryFindBestAntonym(word);
        }

                /// <summary>
        /// Invert words to their antonym in proposition
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <param name="desiredOccurenceReplacement">desired occurence replacement</param>
        /// <returns>Proposition with inverted antonym</returns>
        public static string InvertAntonym(this string originalProposition, int desiredOccurenceReplacement)
        {
            return synonymManager.InvertAntonym(originalProposition, desiredOccurenceReplacement);
        }

        /// <summary>
        /// Whether there is a know antonym to replace a word in original proposition
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether there is a know antonym to replace a word in original proposition</returns>
        public static bool ContainsAntonym(this string originalProposition)
        {
            return synonymManager.ContainsAntonym(originalProposition);
        }

        /// <summary>
        /// Whether provied proposition is question or not
        /// </summary>
        /// <param name="originalProposition">provided proposition</param>
        /// <returns>Whether provied proposition is question or not</returns>
        public static bool IsQuestion(this string originalProposition)
        {
            return questionManager.IsQuestion(originalProposition);
        }
        #endregion
    }
}