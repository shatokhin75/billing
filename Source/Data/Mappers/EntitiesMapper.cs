


namespace Data.Mappers
{
    using System.Linq;
    using Data.Contracts.Data;
    
    public static class EntitiesMapper
    {
        public static CurrencyDTO ToDto(this Currency currency)
        {
    	    if (currency == null)
            {
                return null;
            }
    
            var currencyDTO = new CurrencyDTO
            {
                Id = currency.Id,
                Name = currency.Name,
            };
    
            return currencyDTO;
        }
    
        public static Currency ToEntity(this CurrencyDTO currencyDTO)
        {
    	    if (currencyDTO == null)
            {
                return null;
            }
    
            var currency = new Currency
            {
                Id = currencyDTO.Id,
                Name = currencyDTO.Name,
            };
    
            return currency;
        }
    
        public static DepositDTO ToDto(this Deposit deposit)
        {
    	    if (deposit == null)
            {
                return null;
            }
    
            var depositDTO = new DepositDTO
            {
                Id = deposit.Id,
                PaymentStatusID = deposit.PaymentStatusID,
                PaymentAmount = deposit.PaymentAmount,
                ExchangeRate = deposit.ExchangeRate,
                FundingTypeID = deposit.FundingTypeID,
                CurrencyID = deposit.CurrencyID,
                TimeStamp = deposit.TimeStamp,
                Currency = deposit.Currency.ToDto(),
                FundingType = deposit.FundingType.ToDto(),
                PaymentStatus = deposit.PaymentStatus.ToDto(),
            };
    
            return depositDTO;
        }
    
        public static Deposit ToEntity(this DepositDTO depositDTO)
        {
    	    if (depositDTO == null)
            {
                return null;
            }
    
            var deposit = new Deposit
            {
                Id = depositDTO.Id,
                PaymentStatusID = depositDTO.PaymentStatusID,
                PaymentAmount = depositDTO.PaymentAmount,
                ExchangeRate = depositDTO.ExchangeRate,
                FundingTypeID = depositDTO.FundingTypeID,
                CurrencyID = depositDTO.CurrencyID,
                TimeStamp = depositDTO.TimeStamp,
                Currency = depositDTO.Currency.ToEntity(),
                FundingType = depositDTO.FundingType.ToEntity(),
                PaymentStatus = depositDTO.PaymentStatus.ToEntity(),
            };
    
            return deposit;
        }
    
        public static FundingTypeDTO ToDto(this FundingType fundingtype)
        {
    	    if (fundingtype == null)
            {
                return null;
            }
    
            var fundingtypeDTO = new FundingTypeDTO
            {
                Id = fundingtype.Id,
                FundingTypeName = fundingtype.FundingTypeName,
                MinDeposit = fundingtype.MinDeposit,
                MaxDeposit = fundingtype.MaxDeposit,
                MonthlyQuote = fundingtype.MonthlyQuote,
                QuoteActive = fundingtype.QuoteActive,
            };
    
            return fundingtypeDTO;
        }
    
        public static FundingType ToEntity(this FundingTypeDTO fundingtypeDTO)
        {
    	    if (fundingtypeDTO == null)
            {
                return null;
            }
    
            var fundingtype = new FundingType
            {
                Id = fundingtypeDTO.Id,
                FundingTypeName = fundingtypeDTO.FundingTypeName,
                MinDeposit = fundingtypeDTO.MinDeposit,
                MaxDeposit = fundingtypeDTO.MaxDeposit,
                MonthlyQuote = fundingtypeDTO.MonthlyQuote,
                QuoteActive = fundingtypeDTO.QuoteActive,
            };
    
            return fundingtype;
        }
    
        public static FundingTypeCurrencyDTO ToDto(this FundingTypeCurrency fundingtypecurrency)
        {
    	    if (fundingtypecurrency == null)
            {
                return null;
            }
    
            var fundingtypecurrencyDTO = new FundingTypeCurrencyDTO
            {
                Id = fundingtypecurrency.Id,
                CurrencyID = fundingtypecurrency.CurrencyID,
                FundingTypeID = fundingtypecurrency.FundingTypeID,
                Currency = fundingtypecurrency.Currency.ToDto(),
                FundingType = fundingtypecurrency.FundingType.ToDto(),
            };
    
            return fundingtypecurrencyDTO;
        }
    
        public static FundingTypeCurrency ToEntity(this FundingTypeCurrencyDTO fundingtypecurrencyDTO)
        {
    	    if (fundingtypecurrencyDTO == null)
            {
                return null;
            }
    
            var fundingtypecurrency = new FundingTypeCurrency
            {
                Id = fundingtypecurrencyDTO.Id,
                CurrencyID = fundingtypecurrencyDTO.CurrencyID,
                FundingTypeID = fundingtypecurrencyDTO.FundingTypeID,
                Currency = fundingtypecurrencyDTO.Currency.ToEntity(),
                FundingType = fundingtypecurrencyDTO.FundingType.ToEntity(),
            };
    
            return fundingtypecurrency;
        }
    
        public static PaymentStatusDTO ToDto(this PaymentStatus paymentstatus)
        {
    	    if (paymentstatus == null)
            {
                return null;
            }
    
            var paymentstatusDTO = new PaymentStatusDTO
            {
                Id = paymentstatus.Id,
                Status = paymentstatus.Status,
            };
    
            return paymentstatusDTO;
        }
    
        public static PaymentStatus ToEntity(this PaymentStatusDTO paymentstatusDTO)
        {
    	    if (paymentstatusDTO == null)
            {
                return null;
            }
    
            var paymentstatus = new PaymentStatus
            {
                Id = paymentstatusDTO.Id,
                Status = paymentstatusDTO.Status,
            };
    
            return paymentstatus;
        }
    
    }
}

