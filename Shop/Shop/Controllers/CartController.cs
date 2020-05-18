using Models.DAO;
using Models.Model;
using Models.ViewModel;
using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Constants.CartSession];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[Constants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartViewModel>)Session[Constants.CartSession];
            sessionCart.RemoveAll(x => x.product.ID == id);
            Session[Constants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartViewModel>>(cartModel);
            var sessionCart = (List<CartViewModel>)Session[Constants.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.ID == item.product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[Constants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[Constants.CartSession];
            if (cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(x => x.product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartViewModel();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                //Tạo mới đối tượng cart item   
                var item = new CartViewModel();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartViewModel>();
                list.Add(item);
                //gán vào session
                Session[Constants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[Constants.CartSession];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string phone, string address, string email)
        {
            var order = new Order();
           
            order.ShipAddress = address;
            order.ShipPhone = phone;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartViewModel>)Session[Constants.CartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);


                }     
            }
            catch
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}