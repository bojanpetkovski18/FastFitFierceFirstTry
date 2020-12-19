using FastFitFierce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFitFierce.Models.ListProducts
{
    public class ListProductsViewModel
    {
        private dbFFFEntities db = new dbFFFEntities();
        public List<DAL.Product> ListOfProducts { get; set; }

        public ListProductsViewModel CreateModel()
        {
            return new ListProductsViewModel()
            {
                ListOfProducts = db.Products.ToList()
            };
        }
    }
}