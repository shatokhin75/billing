using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Actions
{
    /// <summary>
    /// Defines methods for performable actions which do not return a value.  
    /// </summary>
    internal interface IPerformableAction : IBaseAction
    {
        #region Public Methods

        /// <summary>
        /// Performs the action.
        /// </summary>
        void Perform();

        #endregion
    }

    /// <summary>
    /// Defines methods for performable actions which do return a value.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of return value for Perform().
    /// </typeparam>
    internal interface IPerformableAction<out TResult> : IBaseAction
    {
        #region Public Methods

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <returns>
        /// The result.
        /// </returns>
        TResult Perform();

        #endregion
    }
}
