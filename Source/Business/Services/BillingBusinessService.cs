using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    using Business.Actions;
    using Business.Services;

    using Data;
    using Data.Contracts.Data;

    public class BillingBusinessService : BaseBusinessService, IBillingBusinessService
    {
        public List<FundingTypeDTO> GetAllSupportedFundingTypes()
        {
            var action = new GetAllSupportedFundingTypesAction();
            return this.Perform(action, false);
        }
    }
}
