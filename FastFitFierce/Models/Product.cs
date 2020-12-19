using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFitFierce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Display(Name = "Product Price")]
        [Required]
        [Range(typeof(decimal), "1", "1000000", ErrorMessage = "Invalid Price")]
        public Nullable<decimal> ProductPrice { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Display(Name = "Description")]
        public string Descript { get; set; }
        [Display(Name = "Product Image")]
        public string ProductImg { get; set; }
        public Nullable<bool> isFeatured { get; set; }
        [Required]
        [Range(typeof(int), "0", "100", ErrorMessage = "Invalid Quantity")]
        public Nullable<int> Quantity { get; set; }
        public SelectList Categories { get; set; }
    }
}