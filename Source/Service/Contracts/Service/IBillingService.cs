namespace Service.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using Service.Contracts.Data;

    [ServiceContract]
    public interface IBillingService
    {
        [OperationContract]
        List<FundingTypeData> GetAllSupportedFundingTypes();

        [OperationContract]
        FundingTypeSupportedCurrenciesData GetFundingTypeSupportedCurrencies(int id);
    }
}
