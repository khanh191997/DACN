using Models.DAO;
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
    }
}