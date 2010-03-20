using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linguistics
{
    /// <summary>
    /// Used for generic string manipulations
    /// </summary>
    static class StringManipulations
    {
        #region Parts
        /// <summary>
        /// Used to replace word in string while keeping original case structure
        /// </summary>
        private static KeepCaseReplacer keepCaseReplacer = new KeepCaseReplacer();
        #endregion

        #region Public Methods
        /// <summary>
        /// Replace content in string but keep original case
        /// </summary>
        /// <param name="original">original</param>
        /// <param name="from">to replace</param>
        /// <param name="to">to replace to</param>
        /// <returns>String with replaced content with case kept</returns>
        public static string ReplaceKeepCase(this string original, string from, string to)
        {
            return keepCaseReplacer.Replace(original, from, to);
        }
        #endregion
    }
}