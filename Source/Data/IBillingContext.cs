namespace Data
{
    using System;
    using System.Data.Entity;

    public interface IBillingContext : IDisposable
    {
        DbSet<Currency> Currency { get; set; }
        DbSet<Deposit> Deposit { get; set; }
        DbSet<FundingType> FundingType { get; set; }
        DbSet<FundingTypeCurrency> FundingTypeCurrency { get; set; }
        DbSet<PaymentStatus> PaymentStatus { get; set; }
    }
}
