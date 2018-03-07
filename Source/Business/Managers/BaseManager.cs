namespace Business.Managers
{
    using Data;

    internal abstract class BaseManager
    {
        protected BaseManager(IBillingContext context)
        {
            this.Context = context;
        }

        protected IBillingContext Context { get; private set; }
    }
}
