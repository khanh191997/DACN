using Models.DAO;
using Models.ViewModel;
using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult Menu()
        {
            var model = new ProductDao().GetAllCate();
            return PartialView(model);
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult ListCate()
        {
            var model = new ProductDao().GetAllCate();
            return PartialView(model);
        }
        public ActionResult TopSellingLaptop()
        {
            var model = new ProductDao().ListTopSellingLaptop();
            return PartialView(model);
        }
        public ActionResult TopSellingSmartPhone()
        {
            var model = new ProductDao().ListTopSellingSmartphone();
            return PartialView(model);
        }
        public ActionResult TopSellingWatch()
        {
            var model = new ProductDao().ListTopSellingWatch();
            return PartialView(model);
        }
        public ActionResult ListNewProduct()
        {
            var model = new ProductDao().ListNewProduct();
            return PartialView(model);
        }
        public ActionResult ListTopSelling()
        {
            var model = new ProductDao().ListTopSelling();
            return PartialView(model);
        }
        public ActionResult ViewCart()
        {
            var cart = Session[Constants.CartSession];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
            }
            return PartialView(list);
        }
    }
}