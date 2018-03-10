namespace Service.Contracts.Data
{
    using System.Collections.Generic;

    public class FundingTypeSupportedCurrenciesData
    {
        public string FundingTypeName { get; set; }
        public decimal MinDeposit { get; set; }
        public decimal MaxDeposit { get; set; }

        public List<int> Currencies { get; set; } 
    }
}
