using Models.DAO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            var model = new ProductDao().GetAllCate();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult ProductSupplier()
        {
            var model = new ProductDao().GetAllSup();
            return PartialView(model);
        }
        public ActionResult TopSelling()
        {
            var model = new ProductDao().ListTopSelling();
            return PartialView(model);
        }

        public ActionResult Category(int cateID, int page = 1, int pageSize = 6)
        {
            var category = new ProductDao().CateViewDetail(cateID);
            ViewBag.Category = category;
            int totalRecord = 0;
            
            var model = new ProductDao().ListByCategoryID(cateID, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize)) +1;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Detail(int id)
        {
           
            var product = new ProductDao().ViewDetail(id);
            ProductViewModel model = new ProductViewModel()
            {
                ID=product.ID,
                Name=product.Name,
                Code = product.Code,
                Descriptions = product.Descriptions,
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateDate = product.CreateDate,
                Status = product.Status 
            };
            var category = new ProductDao().CateViewDetail(product.CategoryID);
            ViewBag.Category = category;
            return View(model);

        }
        public ActionResult RelatedProduct()
        {
            var model = new ProductDao().ListNewProduct();
            return PartialView(model);
        }
    }
}