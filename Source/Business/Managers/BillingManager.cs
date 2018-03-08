namespace Business.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Data.Contracts.Data;
    using Data.Mappers;

    internal sealed class BillingManager : BaseManager
    {
        public BillingManager(IBillingContext context)
            : base(context)
        {
        }

        public List<FundingTypeDTO> GetAllSupportedFundingTypes()
        {
            var result = this.Context.FundingType.AsNoTracking().ToList().Select(a => a.ToDto()).ToList();
            return result;
        }
    }
}
