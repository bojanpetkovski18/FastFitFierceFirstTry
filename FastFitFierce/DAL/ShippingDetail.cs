//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastFitFierce.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShippingDetail
    {
        public int ShippingDetailsId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
