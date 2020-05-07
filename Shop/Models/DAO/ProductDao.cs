﻿using Models.Model;
using Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDao
    {
        ModelDbContext db = null;
        public ProductDao()
        {
            db = new ModelDbContext();
        }
        public IEnumerable<ProductViewModel> ListAllPaging(string searchString, int page, int pageSize)
        {
            //IQueryable<Product> model = db.Products.OrderByDescending(x => x.CreateDate);
            IQueryable<ProductViewModel> models = from p in db.Products
                                                  join s in db.Suppliers
                                                  on p.SupplierID equals s.ID
                                                  join c in db.Categories
                                                  on p.CategoryID equals c.ID
                                                  select new ProductViewModel
                                                  {
                                                      ID = p.ID,
                                                      Name = p.Name,
                                                      Code = p.Code,
                                                      Descriptions = p.Descriptions,
                                                      Image = p.Image,
                                                      Price = p.Price,
                                                      Quantity = p.Quantity,
                                                      CreateDate = p.CreateDate,
                                                      Status = p.Status,
                                                      SupplierName = s.Name,
                                                      CateName = c.Name

                                                  };
            if (!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return models.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public long Insert(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
            return product.ID;

        }
        public bool Update(Product product)
        {
            try
            {
                var products = db.Products.Find(product.ID);
                products.Name = product.Name;
                products.Code = product.Code;
                products.Descriptions = product.Descriptions;
                products.Price = product.Price;
                products.Quantity = product.Quantity;

                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public Product GetById(int id)
        {
            return db.Products.SingleOrDefault(x => x.ID == id);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public List<ProductViewModel> GetAll()
        {
            var models = from p in db.Products
                         join s in db.Suppliers
                         on p.SupplierID equals s.ID
                         join c in db.Categories
                         on p.CategoryID equals c.ID
                         select new ProductViewModel
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Code = p.Code,
                             Descriptions = p.Descriptions,
                             Image = p.Image,
                             Price = p.Price,
                             Quantity = p.Quantity,
                             CreateDate = p.CreateDate,
                             Status = p.Status,
                             SupplierName = s.Name,
                             CateName = c.Name

                         };
            return models.OrderByDescending(x => x.CreateDate).ToList();
        }
        public List<CategoryViewModel> GetAllCate()
        {
            var model = from c in db.Categories
                        select new CategoryViewModel
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Descriptions = c.Descriptions
                        };
            return model.ToList();

        }
        public List<Supplier> GetAllSup()
        {
            return db.Suppliers.ToList();

        }
        public Category CateViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
        public List<ProductViewModel> ListNewProduct(int categoryID)
        {
            var models = from p in db.Products
                         join s in db.Suppliers
                         on p.SupplierID equals s.ID
                         join c in db.Categories
                         on p.CategoryID equals c.ID
                         where p.CategoryID == categoryID
                         select new ProductViewModel
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Code = p.Code,
                             Descriptions = p.Descriptions,
                             Image = p.Image,
                             Price = p.Price,
                             Quantity = p.Quantity,
                             CreateDate = p.CreateDate,
                             Status = p.Status,
                             SupplierName = s.Name,
                             CateName = c.Name

                         };
            return models.OrderByDescending(x => x.CreateDate).Take(4).ToList();
        }
        public List<ProductViewModel> ListByCategoryID(int cateId, ref int totalRecord, int pageIndex = 1, int pageSize = 6)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == cateId).Count();
            var models = from p in db.Products
                         join s in db.Suppliers
                         on p.SupplierID equals s.ID
                         join c in db.Categories
                         on p.CategoryID equals c.ID
                         where p.CategoryID == cateId
                         select new ProductViewModel
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Code = p.Code,
                             Descriptions = p.Descriptions,
                             Image = p.Image,
                             Price = p.Price,
                             Quantity = p.Quantity,
                             CreateDate = p.CreateDate,
                             Status = p.Status,
                             SupplierName = s.Name,
                             CateName = c.Name

                         };
            return models.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> ListTopSelling(int categoryID)
        {
            var models = (from item in db.OrderDetails
                          group item.Quantity by item.Product into g
                          orderby g.Sum() descending
                          select g.Key
                          ).Take(4);
            return models.ToList();
        }
    }
}