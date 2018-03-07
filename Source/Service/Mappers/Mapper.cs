namespace Service.Mappers
{
    using Data.Contracts.Data;

    using Service.Contracts.Data;

    public static class Mapper
    {
        public static FundingTypeData ToDto(this FundingTypeDTO fundingTypeDTO)
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
    }
}
