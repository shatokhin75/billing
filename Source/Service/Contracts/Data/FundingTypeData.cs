using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Data
{
    public class FundingTypeData
    {
        public string FundingTypeName { get; set; }
        public decimal MinDeposit { get; set; }
        public decimal MaxDeposit { get; set; }
        public decimal MonthlyQuote { get; set; }
    }
}
