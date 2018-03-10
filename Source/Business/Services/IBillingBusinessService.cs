namespace Business
{
    using System.Collections.Generic;

    using Data;
    using Data.Contracts.Data;

    public interface IBillingBusinessService
    {
        List<FundingTypeDTO> GetAllSupportedFundingTypes();
        
        FundingTypeDTO GetFundingTypeSupportedCurrencies(int id);

        void SetFundingTypeDeposits(int fundingTypeId, int depositId);
    }
}
