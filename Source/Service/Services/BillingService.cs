namespace Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Service.Adapters;
    using Service.Contracts;
    using Service.Contracts.Data;

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BillingService : IBillingService
    {
        /// <summary>
        /// The adapter.
        /// </summary>
        private readonly BillingServiceAdapter adapter = new BillingServiceAdapter();

        public List<FundingTypeData> GetAllSupportedFundingTypes()
        {
            return this.adapter.GetAllSupportedFundingTypes();
        }
    }
}
