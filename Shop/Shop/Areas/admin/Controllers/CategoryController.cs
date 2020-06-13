using Models.DAO;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: admin/Category
        public ActionResult Index(string searchString)
        {
            var model = new ProductDao().GetListCate(searchString);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = new ProductDao().CateViewDetail(id);
            return View(model);
        }
        [HttpPost]

        public ActionResult Create(Category cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                long id = dao.InsertCate(cate);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công.");
                }
            }
            return View("Index");
        }
        [HttpPost]

        public ActionResult Edit(Category cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.UpdateCate(cate);
                if (result)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công.");
                }
            }
            return View("Index");
        }
        [HttpDelete]

        public ActionResult Delete(int id)
        {
            new ProductDao().DeleteCate(id);

            return RedirectToAction("Index");
        }
    }
}