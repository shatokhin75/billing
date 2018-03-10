namespace Business.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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

        public void SetFundingTypeDeposits(int fundingTypeId, int depositId)
        {
            var deposit = this.Context.Deposit.Find(depositId);
            var fundingType = this.Context.FundingType.Find(fundingTypeId);
            var approvedPaymentStatus = this.Context.PaymentStatus.Single(s => s.Status == "Approved");
            if (deposit == null || fundingType == null)
            {
                throw new ArgumentException();
            }

            var currentQuote =
                approvedPaymentStatus
                    .Deposit.Where(
                        d => d.FundingTypeID == fundingTypeId && d.TimeStamp > new DateTime(2016, 12, 31) && d.TimeStamp < new DateTime(2017, 2, 1))
                        .Sum(s => s.ExchangeRate * s.PaymentAmount);
            var monthlyQuote = fundingType.MonthlyQuote;
            if (currentQuote < monthlyQuote)
            {
                deposit.PaymentStatus = approvedPaymentStatus;
                fundingType.QuoteActive = 0;
                ((DbContext)this.Context).SaveChanges();
            }
        }
    }
}
