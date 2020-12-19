using FastFitFierce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFitFierce.Models.ListProducts
{
    public class ListGearVIewModel
    {
        public List<DAL.Product> ListOfProducts { get; set; }
        private dbFFFEntities db = new dbFFFEntities();

        public ListGearVIewModel CreateModel()
        {
            return new ListGearVIewModel()
            {
                ListOfProducts = db.Products.Where(m => m.CategoryId == 6).ToList()
            };
        }
    }
}