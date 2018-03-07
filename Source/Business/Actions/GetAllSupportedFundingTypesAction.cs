using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Actions
{
    using Business.Managers;

    using Data.Contracts.Data;

    internal class GetAllSupportedFundingTypesAction : PerformableAction<List<FundingTypeDTO>>
    {
        public override List<FundingTypeDTO> Perform()
        {
            var manager = new BillingManager(this.DbContext);
            return manager.GetAllSupportedFundingTypes();
        }
    }
}
