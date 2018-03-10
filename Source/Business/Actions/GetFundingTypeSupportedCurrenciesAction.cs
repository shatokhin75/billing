namespace Business.Actions
{
    using System.Collections.Generic;

    using Business.Managers;

    using Data.Contracts.Data;

    internal class GetFundingTypeSupportedCurrenciesAction : PerformableAction<FundingTypeDTO>
    {
        public GetFundingTypeSupportedCurrenciesAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public override FundingTypeDTO Perform()
        {
            var manager = new BillingManager(this.DbContext);
            return manager.GetFundingTypeSupportedCurrencies(this.Id);
        }
    }
}
