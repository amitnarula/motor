//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace motor.logic.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentCard
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public System.DateTime Expiry { get; set; }
    
        public virtual User User { get; set; }
    }
}