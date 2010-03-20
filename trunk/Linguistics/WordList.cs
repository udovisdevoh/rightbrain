using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Word list from file
    /// </summary>
    internal class WordList
    {
        #region Parts
        /// <summary>
        /// Will contain the words
        /// </summary>
        private HashSet<string> internalHash;
        #endregion

        #region Constructor
        /// <summary>
        /// Create word list from text file
        /// </summary>
        /// <param name="fileName">file name</param>
        public WordList(string fileName)
        {
            internalHash = new HashSet<string>();
            #warning Implement load of text file into internal hash

        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Whether word is in word list as negative or positive form
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is in word list as negative or positive form</returns>
        internal bool ContainsAsNegativeOrPositiveForm(string word)
        {
            word = word.ToLower();
            if (word.EndsWith("n't"))
                word = word.Substring(0, word.Length - 3);

            return ContainsExact(word);
        }

        /// <summary>
        /// Whether word is in word list as exact form
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>Whether word is in word list as exact form</returns>
        internal bool ContainsExact(string word)
        {
            word = word.ToLower();
            return internalHash.Contains(word);
        }
        #endregion
    }
}
