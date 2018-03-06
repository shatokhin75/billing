


namespace Data.Contracts.Data
{
    using System;
    using System.Collections.Generic;
    
    public class DepositDTO
    {
        public int Id { get; set; }
        public int PaymentStatusID { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public int FundingTypeID { get; set; }
        public int CurrencyID { get; set; }
        public System.DateTime TimeStamp { get; set; }
    
        public CurrencyDTO Currency { get; set; }
        public FundingTypeDTO FundingType { get; set; }
        public PaymentStatusDTO PaymentStatus { get; set; }
    }
}

