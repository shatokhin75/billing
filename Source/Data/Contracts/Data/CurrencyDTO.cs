

using System;
using System.Collections.Generic;

public class CurrencyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<DepositDTO> Deposit { get; set; }
    public List<FundingTypeCurrencyDTO> FundingTypeCurrency { get; set; }
}
