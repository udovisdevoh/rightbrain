using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Performs negation of proposions
    /// </summary>
    internal class NegationAndAntonymManager
    {
        #region Internal Methods
        /// <summary>
        /// Invert negation of proposition by removing or adding words like "not" or by replacing a word to an antonym
        /// </summary>
        /// <param name="originalProposition">original proposition</param>
        /// <returns>Proposition with inverted negation or with antonyms</returns>
        internal string InvertNegation(string originalProposition)
        {
            if (originalProposition.ContainsWord("not"))
                return originalProposition.RemoveWord("not", 1);
            else if (originalProposition.Contains("n't"))
                return ntManager.RemoveNt(originalProposition);
            else if (originalProposition.ContainsPresentParticiple())
                return notManager.AddNotBeforeFirstPresentParticiple(originalProposition);
            else if (originalProposition.ContainsVerb())
                return dontDoesntManager.AddDontOrDoesntBeforeFirstVerb(originalProposition);//be careful if there is a "do" before verb
        }
        #endregion
    }
}
