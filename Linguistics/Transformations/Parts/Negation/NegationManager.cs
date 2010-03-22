using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Performs negation of proposions
    /// </summary>
    internal class NegationManager
    {
        #region Parts
        /// <summary>
        /// Manages words like "don't" and "didn't" and "doesn't"
        /// </summary>
        private NtManager ntManager = new NtManager();

        /// <summary>
        /// Manages operations on the word "not"
        /// </summary>
        private NotManager notManager = new NotManager();

        /// <summary>
        /// Manages operations on the word "ain't"
        /// </summary>
        private AintManager aintManager = new AintManager();

        /// <summary>
        /// Manages operations on antonyms
        /// </summary>
        private static SynonymManager synonymManager = new SynonymManager("Linguistics/WordLists/antonymList.xml");
        #endregion

        #region Internal Methods
        /// <summary>
        /// Invert negation of proposition by removing or adding words like "not" or by replacing a word to an antonym
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Proposition with inverted negation or with antonyms</returns>
        internal string InvertNegation(string originalProposition)
        {
            /*if (antonymManager.ContainsAntonym(originalProposition))
                return antonymManager.InvertAntonym(originalProposition, 1);//must be put at first
            else */if (originalProposition.ContainsWord("not"))
                return originalProposition.RemoveWord("not", 1);
            else if (originalProposition.ContainsWord("ain't"))
                return aintManager.RemoveAintOnce(originalProposition);
            else if (originalProposition.ToLower().Contains("n't"))
                return ntManager.RemoveNt(originalProposition, 1);
            else if (ntManager.ContainsNtAbleWord(originalProposition))
                return ntManager.AddNt(originalProposition, 1);
            else if (ContainsWordEndingWithIng(originalProposition))
                return notManager.AddNotBeforeFirstWordEndingWithIng(originalProposition);
            else if (Analysis.ContainsVerb(originalProposition))
                return ntManager.AddDontBeforeFirstVerb(originalProposition);

            #warning AntonymManager must be uncommented along with insertWord
            //return originalProposition.InsertWord(0,"It's not like");

            return originalProposition;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Whether text contains a word ending with ing or in'
        /// </summary>
        /// <param name="text">text to analyze</param>
        /// <returns>Whether text contains a word ending with ing or in'</returns>
        private bool ContainsWordEndingWithIng(string text)
        {
            WordStringStream wordStringStream = new WordStringStream(text);
            foreach (string word in wordStringStream)
                if (word.ToLower().EndsWith("ing") || word.ToLower().EndsWith("in'"))
                    return true;
            return false;
        }
        #endregion
    }
}
