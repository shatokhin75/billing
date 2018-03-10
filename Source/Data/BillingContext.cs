namespace Data
{
    using System.Data.Entity.Core.EntityClient;

    public partial class BillingContext : IBillingContext
    {

        public static IBillingContext Create()
        {
            return new BillingContext();
        }
    }
}
