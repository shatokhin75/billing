namespace Business.Actions
{
    using Data;

    internal abstract class PerformableAction<T> : IPerformableAction<T>
    {
        public abstract T Perform();

        public IBillingContext DbContext { get; set; }
    }
}
