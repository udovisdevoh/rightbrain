using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages analysis of verbs
    /// </summary>
    class VerbManager
    {
        #region Parts
        /// <summary>
        /// List of modal verb
        /// </summary>
        private WordListFromFile modalVerbList;

        /// <summary>
        /// List of irregular verb
        /// </summary>
        private WordListFromFile irregularVerbList;

        /// <summary>
        /// List of regular verb
        /// </summary>
        private WordListFromFile regularVerbList;

        /// <summary>
        /// List of undefined verb
        /// </summary>
        private WordListFromFile undefinedVerbList;
        #endregion

        #region Constructor
        /// <summary>
        /// Create verb manager
        /// </summary>
        public VerbManager()
        {
            modalVerbList = new WordListFromFile("Linguistics/WordLists/modalVerbList.txt");
            irregularVerbList = new WordListFromFile("Linguistics/WordLists/irregularVerbList.txt");
            regularVerbList = new WordListFromFile("Linguistics/WordLists/regularVerbList.txt");
            undefinedVerbList = new WordListFromFile("Linguistics/WordLists/undefinedVerbList.txt");
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Whether the word is a verb
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is a verb</returns>
        internal bool IsVerb(string word)
        {
            return IsModalVerb(word) || IsIrregularVerb(word) || IsRegularVerb(word) || IsUndefinedVerb(word);
        }

        /// <summary>
        /// Whether the word is in modal verb list
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is in modal verb list</returns>
        internal bool IsModalVerb(string word)
        {
            return modalVerbList.ContainsAsNegativeOrPositiveForm(word);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Whether the word is in irregular verb list
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is in irregular verb list</returns>
        private bool IsIrregularVerb(string word)
        {
            return irregularVerbList.ContainsAsNegativeOrPositiveForm(word);
        }

        /// <summary>
        /// Whether the word is in regular verb list
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is in regular verb list</returns>
        private bool IsRegularVerb(string word)
        {
            return regularVerbList.ContainsAsNegativeOrPositiveForm(word);
        }

        /// <summary>
        /// Whether the word is in undefined verb list
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is in undefined verb list</returns>
        private bool IsUndefinedVerb(string word)
        {
             return undefinedVerbList.ContainsAsNegativeOrPositiveForm(word);
        }
        #endregion
    }
}
