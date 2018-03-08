﻿namespace Service.Test.Controllers
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Service.Contracts.Data;

    [TestFixture]
    public class BillingApiControllerTest : BaseApiControllerTest
    {
        [Test]
        public void GetAllSupportedFundingTypesTest()
        {
            var result = this.TestPostAction<List<FundingTypeData>>("api/v1/GetAllSupportedFundingTypes", string.Empty);
            Assert.IsNotEmpty(result);
        }
    }
}
