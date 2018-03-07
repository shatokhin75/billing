namespace Business.Services
{
    using Business.Actions;

    using Data;

    public abstract class BaseBusinessService
    {
        internal TResult Perform<TResult>(
            IPerformableAction<TResult> action,
            bool transactional = true)
        {
            if (transactional)
            {
                using (IBillingContext context = BillingContext.Create())
                    {
                        using (var transaction = TransactionUtils.CreateTransaction())
                        {
                            action.DbContext = context;
                            TResult result = action.Perform();
                            transaction.Complete();
                            return result;
                        }
                    }
            }
            else
            {
                using (IBillingContext context = BillingContext.Create())
                    {
                        action.DbContext = context;
                        return action.Perform();
                    }
            }
        }
    }
}
