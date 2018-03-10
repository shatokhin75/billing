namespace Service.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Business;

    using Service.Adapters;
    using Service.Contracts.Data;

    [RoutePrefix("api/v1")]
    public class BillingApiController : ApiController
    {
        /// <summary>
        /// The adapter.
        /// </summary>
        private readonly BillingServiceAdapter adapter;

        public BillingApiController()
        {
            adapter = new BillingServiceAdapter(new BillingBusinessService());
        }

        [HttpPost]
        [Route("GetAllSupportedFundingTypes")]
        [ResponseType(typeof(List<FundingTypeData>))]
        public IHttpActionResult GetAllSupportedFundingTypes()
        {
            var result = this.adapter.GetAllSupportedFundingTypes();
            return Json(result);
        }

        [HttpGet]
        [Route("GetFundingTypeSupportedCurrencies/{id}")]
        [ResponseType(typeof(FundingTypeSupportedCurrenciesData))]
        public IHttpActionResult GetFundingTypeSupportedCurrencies(int id)
        {
            var result = this.adapter.GetFundingTypeSupportedCurrencies(id);
            return Json(result);
        }

        [HttpPut]
        [Route("SetPaymentStatusOnQuote")]
        [ResponseType(typeof(void))]
        public IHttpActionResult SetFundingTypeDeposits([FromBody]SetFundingTypeDepositsData data)
        {
            this.adapter.SetFundingTypeDeposits(data.FundingTypeId, data.DepositId);
            return this.Ok();
        }
    }
}
