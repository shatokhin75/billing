//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FundingTypeCurrency
    {
        public int Id { get; set; }
        public int CurrencyID { get; set; }
        public int FundingTypeID { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual FundingType FundingType { get; set; }
    }
}
