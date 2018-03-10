namespace Service.Test.Adapters
{
    using System.Collections.Generic;
    using System.Linq;

    using Business;

    using Data.Contracts.Data;

    using Moq;

    using NUnit.Framework;

    using Service.Adapters;

    [TestFixture]
    public class BillingServiceAdapterTest
    {
        [Test]
        public void GetAllSupportedFundingTypesTest()
        {
            var service = new Mock<IBillingBusinessService>();
            service.Setup(a => a.GetAllSupportedFundingTypes())
                .Returns(
                    new List<FundingTypeDTO>
                        {
                            new FundingTypeDTO
                                {
                                    FundingTypeName = "Name1",
                                    MinDeposit = 0,
                                    MaxDeposit = 10
                                }
                        });
            var adapter = new BillingServiceAdapter(service.Object);
            var result = adapter.GetAllSupportedFundingTypes();
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 1);
            Assert.True(result.Single().FundingTypeName == "Name1");
        }
    }
}
