using FastFitFierce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFitFierce.Models.ListProducts
{
    public class ListSupplementsViewModel
    {
        public List<DAL.Product> ListOfProducts { get; set; }
        private dbFFFEntities db = new dbFFFEntities();

        public ListSupplementsViewModel CreateModel()
        {
            return new ListSupplementsViewModel()
            {
                ListOfProducts = db.Products.Where(m => m.CategoryId == 4).ToList()
            };
        }
    }
}