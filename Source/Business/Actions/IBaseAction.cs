namespace Business.Actions
{
    using Data;

    internal interface IBaseAction
    {
        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        IBillingContext DbContext { get; set; }
    }
}
