using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFitFierce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name is Required.")]
        public string CategoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
    }
}