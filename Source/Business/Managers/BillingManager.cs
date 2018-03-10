namespace Business.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    using Data;
    using Data.Contracts.Data;
    using Data.Mappers;

    internal sealed class BillingManager : BaseManager
    {
        public BillingManager(IBillingContext context)
            : base(context)
        {
        }

        public List<FundingTypeDTO> GetAllSupportedFundingTypes()
        {
            var result = this.Context.FundingType.AsNoTracking().ToList().Select(a => a.ToDto()).ToList();
            return result;
        }

        public FundingTypeDTO GetFundingTypeSupportedCurrencies(int id)
        {
            var result = this.Context.FundingType.AsNoTracking().Where(f => f.Id == id).ToList().Select(f => new FundingTypeDTO
                                 {
                                     Deposit = f.Deposit.ToList().Select(a => a.ToDto()).ToList(),
                                     FundingTypeCurrency =
                                         f.FundingTypeCurrency.ToList().Select(a => a.ToDto()).ToList(),
                                     FundingTypeName = f.FundingTypeName,
                                     Id = f.Id,
                                     MaxDeposit = f.MaxDeposit,
                                     MinDeposit = f.MinDeposit,
                                     MonthlyQuote = f.MonthlyQuote,
                                     QuoteActive = f.QuoteActive
                                 }).Single();
            return result;
        }
    }
}
