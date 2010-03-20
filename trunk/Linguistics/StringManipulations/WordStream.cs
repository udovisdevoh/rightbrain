using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Represents a stream of words that can be extracted form a string
    /// </summary>
    class WordStream
    {
        #region Fields and parts
        /// <summary>
        /// Current pointer in word list
        /// </summary>
        private int pointer = 0;

        /// <summary>
        /// List of words
        /// </summary>
        private List<string> wordList;

        /// <summary>
        /// First delimiter before first word
        /// </summary>
        private string firstDelimiter;

        /// <summary>
        /// List of other delimiters
        /// </summary>
        private List<string> delimiterList;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a word stream from a source text
        /// </summary>
        /// <param name="sourceText">source text</param>
        public WordStream(string sourceText)
        {
            wordList = new List<string>();
            delimiterList = new List<string>();

            string currentWord = string.Empty;
            string currentDelimiter = string.Empty;
            firstDelimiter = string.Empty;
            foreach (char letter in sourceText)
            {
                if (StringManipulations.IsWordDelimiter(letter))
                {
                    currentDelimiter += letter;
                    if (wordList.Count == 0 && currentWord == string.Empty)
                        firstDelimiter += letter;
                    if (currentWord != string.Empty)
                    {
                        wordList.Add(currentWord);
                        currentWord = string.Empty;
                    }
                }
                else
                {
                    if (currentDelimiter != string.Empty)
                    {
                        delimiterList.Add(currentDelimiter);
                        currentDelimiter = string.Empty;
                    }
                    currentWord += letter;
                }
            }
            
            if (currentWord != string.Empty)
            {
                wordList.Add(currentWord);
                currentWord = string.Empty;
            }

            if (currentDelimiter != string.Empty)
            {
                delimiterList.Add(currentDelimiter);
                currentDelimiter = string.Empty;
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// Try get next word and delimiter from word stream
        /// </summary>
        /// <param name="nextWord">next word</param>
        /// <param name="nextDelimiter">next word delimiter (can be null if it's the last word)</param>
        /// <returns>whether there are still words to get</returns>
        public bool TryGetNextWord(out string nextWord, out string nextDelimiter)
        {
            nextWord = null;
            nextDelimiter = null;
            if (pointer >= wordList.Count)
                return false;

            nextWord = wordList[pointer];

            if (pointer < delimiterList.Count)
                nextDelimiter = delimiterList[pointer];

            pointer++;
            return true;
        }

        /// <summary>
        /// Reset the word pointer
        /// </summary>
        public void Reset()
        {
            pointer = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// First delimiter before first word
        /// </summary>
        public string FirstDelimiter
        {
            get { return firstDelimiter; }
        }
        #endregion
    }
}
