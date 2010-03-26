using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Manages operations on antonyms
    /// </summary>
    internal class SynonymManager
    {
        #region Constants
        /// <summary>
        /// File name for antonym list
        /// </summary>
        private const string antonymListFileName = "Matrix/xmlMatrixFiles/antonymList.xml";

        /// <summary>
        /// File name for synonym list
        /// </summary>
        private const string synonymListFileName = "Matrix/xmlMatrixFiles/synonymList.xml";
        #endregion

        #region Fields and parts
        /// <summary>
        /// Manages saving and loading matrixes
        /// </summary>
        private XmlMatrixSaverLoader xmlMatrixSaverLoader = new XmlMatrixSaverLoader();

        /// <summary>
        /// Matrix that will contain synonyms
        /// Don't use directly, use synonymMatrix instead
        /// </summary>
        private Matrix _synonymMatrix = null;

        /// <summary>
        /// Matrix that will contain antonyms
        /// Don't use directly, use antonymMatrix instead
        /// </summary>
        private Matrix _antonymMatrix = null;
        #endregion

        #region Public Methods
        /// <summary>
        /// Try find an antonym for provided word or return false if none found
        /// </summary>
        /// <param name="originalWord">original word</param>
        /// <returns>Try find an antonym for provided word or return false if none found</returns>
        private string TryFindAntonym(string originalWord)
        {
            originalWord = originalWord.ToLower().Trim();

            Dictionary<string,float> matrixData;

            if (antonymMatrix.NormalData.TryGetValue(originalWord, out matrixData))
            {
                if (matrixData.Count < 1)
                    return null;

                foreach (string key in matrixData.Keys)
                    return key;

            }
            else if (antonymMatrix.ReversedData.TryGetValue(originalWord, out matrixData))
            {
                if (matrixData.Count < 1)
                    return null;

                foreach (string key in matrixData.Keys)
                    return key;
            }
            
            return null;
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Invert words to their antonym in proposition
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <param name="desiredOccurenceReplacement">desired occurence replacement</param>
        /// <returns>Proposition with inverted antonym</returns>
        internal string InvertAntonym(string originalProposition, int desiredOccurenceReplacement)
        {
            WordStream wordStream = new WordStream(originalProposition);

            int replacementCount = 0;
            foreach (Word word in wordStream)
            {
                if (replacementCount < desiredOccurenceReplacement)
                {
                    string foundAntoym = TryFindAntonym(word.StringValue);
                    if (foundAntoym != null)
                    {
                        word.StringValue = foundAntoym;
                        replacementCount++;
                    }
                }
            }

            return wordStream.ToString();
        }

        /// <summary>
        /// Whether there is a know antonym to replace a word in original proposition
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Whether there is a know antonym to replace a word in original proposition</returns>
        internal bool ContainsAntonym(string originalProposition)
        {
            WordStringStream wordStringStream = new WordStringStream(originalProposition);

            foreach (string word in wordStringStream)
                if (antonymMatrix.NormalData.ContainsKey(word.ToLower()))
                    return true;

            foreach (string word in wordStringStream)
                if (antonymMatrix.ReversedData.ContainsKey(word.ToLower()))
                    return true;

            return false;
        }
        #endregion

        #region Lazy initializations
        /// <summary>
        /// Matrix that will contain synonyms
        /// </summary>
        private Matrix synonymMatrix
        {
            get
            {
                if (_synonymMatrix == null)
                    _synonymMatrix = xmlMatrixSaverLoader.Load(synonymListFileName);

                return _synonymMatrix;
            }
        }

        /// <summary>
        /// Matrix that will contain antonyms
        /// </summary>
        private Matrix antonymMatrix
        {
            get
            {
                if (_antonymMatrix == null)
                    _antonymMatrix = xmlMatrixSaverLoader.Load(antonymListFileName);

                return _antonymMatrix;
            }
        }
        #endregion
    }
}
