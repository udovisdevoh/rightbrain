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
        private WordList modalVerbList = new WordList("modalVerbList.txt");

        /// <summary>
        /// List of irregular verb
        /// </summary>
        private WordList irregularVerbList = new WordList("irregularVerbList.txt");

        /// <summary>
        /// List of regular verb
        /// </summary>
        private WordList regularVerbList = new WordList("regularVerbList.txt");

        /// <summary>
        /// List of undefined verb
        /// </summary>
        private WordList undefinedVerbList = new WordList("undefinedVerbList.txt");
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
        #endregion

        #region Private Methods
        /// <summary>
        /// Whether the word is in modal verb list
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether the word is in modal verb list</returns>
        private bool IsModalVerb(string word)
        {
            return modalVerbList.ContainsAsNegativeOrPositiveForm(word);
        }

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
