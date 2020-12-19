using FastFitFierce.DAL;
using FastFitFierce.Models;
using FastFitFierce.Repos;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Category = FastFitFierce.DAL.Category;
using Product = FastFitFierce.DAL.Product;

namespace FastFitFierce.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private dbFFFEntities db = new dbFFFEntities();

        public List<SelectListItem> getAllCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var categories = db.Categories.ToList();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

        // GET: Categories
        public ActionResult Categories()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Create
        public ActionResult CreateCategory()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "CategoryId,CategoryName,isActive,isDelete")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Categories");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "CategoryId,CategoryName,isActive,isDelete")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(category);
        }

       
        public ActionResult DeleteCategory(int? id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        // GET: Products
        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Create
        public ActionResult CreateProduct()
        {
            ViewBag.CategoryList = getAllCategories();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "ProductId,CategoryId,ProductName,ProductPrice,isActive,isDelete,CreatedDate,ModifiedDate,Descript,ProductImg,isFeatured,Quantity,Categories")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Products");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryList = getAllCategories();
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "ProductId,CategoryId,ProductName,ProductPrice,isActive,isDelete,CreatedDate,ModifiedDate,Descript,ProductImg,isFeatured,Quantity,Categories")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ModifiedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Products");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}