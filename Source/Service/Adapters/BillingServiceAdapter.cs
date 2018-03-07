using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    using Business;

    using Service.Contracts.Data;
    using Service.Mappers;

    internal sealed class BillingServiceAdapter
    {
        // <summary>
        /// The service.
        /// </summary>
        private readonly IBillingBusinessService billingBusinessService;

        public BillingServiceAdapter()
        {
            this.billingBusinessService = new BillingBusinessService();
        }

        public List<FundingTypeData> GetAllSupportedFundingTypes()
        {
            return this.billingBusinessService.GetAllSupportedFundingTypes().Select(a => a.ToDto()).ToList();
        }
    }
}
