namespace Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Business;

    using Service.Adapters;
    using Service.Contracts;
    using Service.Contracts.Data;

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BillingService : IBillingService
    {
        /// <summary>
        /// The adapter.
        /// </summary>
        private readonly BillingServiceAdapter adapter;

        public BillingService()
        {
            this.adapter = new BillingServiceAdapter(new BillingBusinessService());
        }

        public List<FundingTypeData> GetAllSupportedFundingTypes()
        {
            return this.adapter.GetAllSupportedFundingTypes();
        }

        public FundingTypeSupportedCurrenciesData GetFundingTypeSupportedCurrencies(int id)
        {
            return this.adapter.GetFundingTypeSupportedCurrencies(id);
        }

        public void SetFundingTypeDeposits(int fundingTypeId, int depositId)
        {
            this.adapter.SetFundingTypeDeposits(fundingTypeId, depositId);
        }
    }
}
