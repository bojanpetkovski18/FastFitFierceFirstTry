using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFitFierce.Models
{
    public class ShippingDetails
    {
        public int ShippingDetailsId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
    }
   
}