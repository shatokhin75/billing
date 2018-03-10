namespace Service.Adapters
{
    using System.Collections.Generic;
    using System.Linq;

    using Business;

    using Service.Contracts.Data;
    using Service.Mappers;

    internal sealed class BillingServiceAdapter
    {
        // <summary>
        /// The service.
        /// </summary>
        private readonly IBillingBusinessService billingBusinessService;

        public BillingServiceAdapter(IBillingBusinessService billingBusinessService)
        {
            this.billingBusinessService = billingBusinessService;
        }

        public List<FundingTypeData> GetAllSupportedFundingTypes()
        {
            return this.billingBusinessService.GetAllSupportedFundingTypes().Select(a => a.ToFundingTypeDataDto()).ToList();
        }

        public FundingTypeSupportedCurrenciesData GetFundingTypeSupportedCurrencies(int id)
        {
            return this.billingBusinessService.GetFundingTypeSupportedCurrencies(id).ToFundingTypeSupportedCurrenciesDataDto();
        }

        public void SetFundingTypeDeposits(int fundingTypeId, int depositId)
        {
            this.billingBusinessService.SetFundingTypeDeposits(fundingTypeId, depositId);
        }
    }
}
