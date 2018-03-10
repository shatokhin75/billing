namespace Service.Mappers
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Contracts.Data;

    using Service.Contracts.Data;

    public static class Mapper
    {
        public static FundingTypeData ToFundingTypeDataDto(this FundingTypeDTO fundingTypeDTO)
        {
            if (fundingTypeDTO == null)
            {
                return null;
            }

            return new FundingTypeData
            {
                FundingTypeName = fundingTypeDTO.FundingTypeName,
                MaxDeposit = fundingTypeDTO.MaxDeposit,
                MinDeposit = fundingTypeDTO.MinDeposit,
                MonthlyQuote = fundingTypeDTO.MonthlyQuote
            };
        }

        public static FundingTypeSupportedCurrenciesData ToFundingTypeSupportedCurrenciesDataDto(this FundingTypeDTO fundingTypeDTO)
        {
            if (fundingTypeDTO == null)
            {
                return null;
            }

            var result = new FundingTypeSupportedCurrenciesData
                             {
                                 FundingTypeName = fundingTypeDTO.FundingTypeName,
                                 MaxDeposit = fundingTypeDTO.MaxDeposit,
                                 MinDeposit = fundingTypeDTO.MinDeposit,
                                 Currencies =
                                     fundingTypeDTO.FundingTypeCurrency.Any()
                                         ? fundingTypeDTO.FundingTypeCurrency.Select(
                                             f => f.Id).ToList()
                                         : new List<int> { -1 },
                             };

            return result;
        }
    }
}
