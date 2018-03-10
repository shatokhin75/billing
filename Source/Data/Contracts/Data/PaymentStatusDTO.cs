


namespace Data.Contracts.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
    
        public List<DepositDTO> Deposit { get; set; }
    }
}

