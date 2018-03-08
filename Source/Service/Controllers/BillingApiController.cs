namespace Service.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Service.Adapters;
    using Service.Contracts.Data;

    [RoutePrefix("api/v1")]
    public class BillingApiController : ApiController 
    {
        /// <summary>
        /// The adapter.
        /// </summary>
        private readonly BillingServiceAdapter adapter = new BillingServiceAdapter();

        [HttpPost]
        [Route("GetAllSupportedFundingTypes")]
        [ResponseType(typeof(List<FundingTypeData>))]
        public IHttpActionResult GetAllSupportedFundingTypes()
        {
            var result = this.adapter.GetAllSupportedFundingTypes();
            return Json(result);
        }
    }
}
