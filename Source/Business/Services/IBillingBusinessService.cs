namespace Business
{
    using System.Collections.Generic;

    using Data;
    using Data.Contracts.Data;

    public interface IBillingBusinessService
    {
        List<FundingTypeDTO> GetAllSupportedFundingTypes();
    }
}
