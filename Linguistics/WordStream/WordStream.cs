using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Represents a stream of words that can be extracted and manipulated form a string
    /// </summary>
    public class WordStream : WordStringStream, IEnumerable<Word>
    {
        #region Fields and parts
        /// <summary>
        /// List of words
        /// </summary>
        private List<Word> wordList;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a word stream
        /// </summary>
        /// <param name="originalText">original text</param>
        public WordStream(string originalText) : base(originalText)
        {
            wordList = new List<Word>();

            WordStringStream wordStringStream = new WordStringStream(originalText);

            string nextWordAsString, nextDelimiterAsString;
            bool isSentenceBegin;
            Word previousWord = null;
            string previousDelimiter = wordStringStream.FirstDelimiter;

            while (wordStringStream.TryGetNextWord(out nextWordAsString, out nextDelimiterAsString, out isSentenceBegin))
            {
                Word currentWord = new Word(nextWordAsString);
                currentWord.LeftDelimiter = previousDelimiter;
                currentWord.RightDelimiter = nextDelimiterAsString;
                currentWord.IsSentenceBegin = isSentenceBegin;
                wordList.Add(currentWord);

                if (previousWord != null)
                {
                    previousWord.NextWord = currentWord;
                    currentWord.PreviousWord = previousWord;
                }

                previousWord = currentWord;
                previousDelimiter = nextDelimiterAsString;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Try to get next word and advance pointer
        /// </summary>
        /// <param name="word">next word (can be null if none available</param>
        /// <returns>Whether could get next word or not</returns>
        public bool TryGetNextWord(out Word word)
        {
            if (pointer >= wordList.Count)
            {
                word = null;
                return false;
            }

            word = wordList[pointer];

            pointer++;
            return true;
        }
        #endregion

        #region IEnumerable<Word> Members
        public new IEnumerator<Word> GetEnumerator()
        {
            return wordList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return wordList.GetEnumerator();
        }
        #endregion
    }
}
