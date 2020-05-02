using Model.DAO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Model.ViewModel;

namespace Server.Api
{
    public class ProductApiController : ApiController
    {
        [HttpGet]
        [Route("api/Product/LoadProduct")]
        public List<ProductViewModel> LoadProduct()
        {
            //ModelDBContext.Configuration.ProxyCreationEnabled = false;
            List<ProductViewModel> pros = new ProductDao().GetAll();
            return pros;
        }
        [HttpGet]
        [Route("api/Product/LoadCate")]
        public List<CategoryViewModel> LoadCate()
        {
            //ModelDBContext.Configuration.ProxyCreationEnabled = false;
            List<CategoryViewModel> cate = new ProductDao().GetAllCate();
            return cate;
        }
        [HttpPost]
        [Route("api/Product/AddNew")]
        public long AddNew(Product pro)
        {
            long result = new ProductDao().Insert(pro);
            return result;
        }
    }
}
