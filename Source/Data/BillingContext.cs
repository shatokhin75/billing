namespace Data
{
    using System.Data.Entity.Core.EntityClient;

    public partial class BillingContext : IBillingContext
    {
        /// <summary>
        /// The MSSQL entity framework metadata description string.
        /// </summary>
        private const string MssqlEntityFramewordMetadata = "metadata=res://*/Mssql.Wilco.csdl|res://*/Mssql.Wilco.ssdl|res://*/Mssql.Wilco.msl;provider=System.Data.SqlClient;";

        internal BillingContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        private static IBillingContext CreateMssqlDbContext(string connectionString = null)
        {
            var builder = new EntityConnectionStringBuilder(MssqlEntityFramewordMetadata)
            {
                ProviderConnectionString = connectionString
            };

            return new BillingContext();
        }

        public static IBillingContext Create(string connectionString = null)
        {
            return CreateMssqlDbContext(connectionString);
        }
    }
}
