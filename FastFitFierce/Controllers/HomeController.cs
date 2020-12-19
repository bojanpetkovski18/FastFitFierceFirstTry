using FastFitFierce.DAL;
using FastFitFierce.Models;
using FastFitFierce.Models.ListProducts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FastFitFierce.Controllers
{
    public class HomeController : Controller
    {
        dbFFFEntities db = new dbFFFEntities();

        public ActionResult Index()
        {
            ListProductsViewModel model = new ListProductsViewModel();
            var model1 = db.Products.Where(x => x.CategoryId == 4).ToList();
            return View(model.CreateModel());
        }

        public ActionResult Supplements()
        {
            ListSupplementsViewModel model = new ListSupplementsViewModel();
            return View(model.CreateModel());
        }

        public ActionResult Gear()
        {
            ListGearVIewModel model = new ListGearVIewModel();
            return View(model.CreateModel());
        }

        public ActionResult Programs()
        {
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            List<Item> cart;
            if (Session["cart"] == null)
            {
                cart = new List<Item>();
            }
            else
            {
                cart = (List<Item>)Session["cart"];
            }

            DAL.Product product = db.Products.Find(productId);
            cart.Add(new Item()
            {
                Product = product
            });

            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            if (Session["cart"] != null)
            {
                foreach (var item in cart)
                {
                    if (item.Product.ProductId.Equals(productId))
                    {
                        cart.Remove(item);
                        break;
                    }
                }
            }


            Session["cart"] = cart;

            return RedirectToAction("Index");
        }


        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult CheckoutEmpty()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}