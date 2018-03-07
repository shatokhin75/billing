namespace Business
{
    using System.Transactions;

    public static class TransactionUtils
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="scope">
        /// The scope, which default to Required (which means to use an existing transaction if available).
        /// </param>
        /// <param name="isolationLevel">
        /// Isolation level
        /// </param>
        /// <returns>
        /// The transaction scope.
        /// </returns>
        public static TransactionScope CreateTransaction(TransactionScopeOption scope = TransactionScopeOption.Required, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new TransactionScope(
                scope,
                new TransactionOptions
                {
                    IsolationLevel = isolationLevel
                });
        }

        #endregion
    }
}
