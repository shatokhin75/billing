namespace Business.Actions
{
    using Business.Managers;

    internal class SetFundingTypeDepositsAction : PerformableAction
    {
        public SetFundingTypeDepositsAction(int fundingTypeId, int depositId)
        {
            this.FundingTypeId = fundingTypeId;
            this.DepositId = depositId;
        }

        public int DepositId { get; set; }

        public int FundingTypeId { get; set; }

        public override void Perform()
        {
            var manager = new BillingManager(this.DbContext);
            manager.SetFundingTypeDeposits(this.FundingTypeId, this.DepositId);
        }
    }
}
