


namespace Data.Contracts.Data
{
    using System;
    using System.Collections.Generic;
    
    public class FundingTypeCurrencyDTO
    {
        public int Id { get; set; }
        public int CurrencyID { get; set; }
        public int FundingTypeID { get; set; }
    
        public CurrencyDTO Currency { get; set; }
        public FundingTypeDTO FundingType { get; set; }
    }
}

