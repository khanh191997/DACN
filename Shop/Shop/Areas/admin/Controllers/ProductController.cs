﻿using Models.DAO;
using Models.Model;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new ProductDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]

        public ActionResult Create(Product product)
        {
            //ViewBag.Category=new SelectList(new ProductDao().GetAllCate().Where(x=>x.CategoryID=myid))
            ViewBag.Category = new ProductDao().GetAllCate().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryID.ToString() }).ToList();
           // ViewBag.Category = new SelectList(new ProductDao().GetAllCate().ToList(), "ID", "Name");
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                long id = dao.Insert(product);
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

        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
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
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}