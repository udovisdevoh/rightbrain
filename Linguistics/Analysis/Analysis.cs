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

        /// <summary>
        /// List of pronouns
        /// </summary>
        private static WordListFromFile pronounList = new WordListFromFile("Linguistics/WordLists/pronounList.txt");

        /// <summary>
        /// List of prepositions
        /// </summary>
        private static WordListFromFile prepositionList = new WordListFromFile("Linguistics/WordLists/prepositionList.txt");

        /// <summary>
        /// List of postpositions
        /// </summary>
        private static WordListFromFile postpositionList = new WordListFromFile("Linguistics/WordLists/postpositionList.txt");
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

        /// <summary>
        /// Whether the word is a pronoun
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is a pronoun</returns>
        public static bool IsPronoun(string word)
        {
            return pronounList.ContainsExact(word);
        }

        /// <summary>
        /// Whether word is a preposition
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is a preposition</returns>
        public static bool IsPreposition(string word)
        {
            return prepositionList.ContainsExact(word);
        }

        /// <summary>
        /// Whether word is a postposition
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is a preposition</returns>
        public static bool IsPostposition(string word)
        {
            return postpositionList.ContainsExact(word);
        }
        #endregion
    }
}
