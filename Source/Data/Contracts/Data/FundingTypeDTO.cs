


namespace Data.Contracts.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FundingTypeDTO
    {
        public int Id { get; set; }
        public string FundingTypeName { get; set; }
        public decimal MinDeposit { get; set; }
        public decimal MaxDeposit { get; set; }
        public decimal MonthlyQuote { get; set; }
        public Nullable<decimal> QuoteActive { get; set; }
    
        public List<DepositDTO> Deposit { get; set; }
        public List<FundingTypeCurrencyDTO> FundingTypeCurrency { get; set; }
    }
}

