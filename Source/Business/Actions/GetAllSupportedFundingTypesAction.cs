// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllSupportedFundingTypesAction.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the GetAllSupportedFundingTypesAction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business.Actions
{
    using System.Collections.Generic;

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
