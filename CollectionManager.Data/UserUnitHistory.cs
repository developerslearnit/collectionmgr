//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollectionManager.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserUnitHistory
    {
        public int UserId { get; set; }
        public decimal UnitPurchased { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime DatePurchased { get; set; }
    
        public virtual User User { get; set; }
    }
}
