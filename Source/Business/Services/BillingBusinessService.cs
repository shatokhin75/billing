namespace Business
{
    using System.Collections.Generic;

    using Business.Actions;
    using Business.Services;

    using Data.Contracts.Data;

    public class BillingBusinessService : BaseBusinessService, IBillingBusinessService
    {
        public List<FundingTypeDTO> GetAllSupportedFundingTypes()
        {
            var action = new GetAllSupportedFundingTypesAction();
            return this.Perform(action, false);
        }

        public FundingTypeDTO GetFundingTypeSupportedCurrencies(int id)
        {
            var action = new GetFundingTypeSupportedCurrenciesAction(id);
            return this.Perform(action, false);
        }
    }
}
