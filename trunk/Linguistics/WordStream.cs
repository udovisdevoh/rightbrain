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

        /// <summary>
        /// List of word indexes that correspound to begining of sentences
        /// </summary>
        private HashSet<int> listSentenceBegin;
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
            listSentenceBegin = new HashSet<int>();

            listSentenceBegin.Add(0);//We add the index of the first word as sentence begining

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

                        if (currentDelimiter.Contains('.') || currentDelimiter.Contains('!') || currentDelimiter.Contains('?'))
                            listSentenceBegin.Add(wordList.Count - 1);

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
            bool isSentenceBegin;
            return TryGetNextWord(out nextWord, out nextDelimiter, out isSentenceBegin);
        }

        /// <summary>
        /// Try get next word and delimiter from word stream
        /// </summary>
        /// <param name="nextWord">next word</param>
        /// <param name="nextDelimiter">next word delimiter (can be null if it's the last word)</param>
        /// <param name="isSentenceBegin">whether current word is the begining of a sentence</param>
        /// <returns>whether there are still words to get</returns>
        public bool TryGetNextWord(out string nextWord, out string nextDelimiter, out bool isSentenceBegin)
        {
            isSentenceBegin = false;
            nextWord = null;
            nextDelimiter = null;
            if (pointer >= wordList.Count)
                return false;

            nextWord = wordList[pointer];

            if (pointer < delimiterList.Count)
                nextDelimiter = delimiterList[pointer];

            isSentenceBegin = listSentenceBegin.Contains(pointer);

            pointer++;
            return true;
        }

        /// <summary>
        /// Try to get next word without advancing pointer
        /// Null if no word left
        /// </summary>
        /// <returns>next word or null if none available</returns>
        public string PeekNextWord()
        {
            if (pointer >= wordList.Count)
                return null;

            return wordList[pointer];
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
