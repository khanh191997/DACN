using Models.Model;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ReportDao
    {
        ModelDbContext db = null;
        public ReportDao()
        {
            db = new ModelDbContext();
        }
        public int CountProduct()
        {
            return db.OrderDetails.Sum(x => x.Quantity).Value;
        }
        public decimal CountEarning()
        {
            return db.OrderDetails.Sum(x => x.Price).Value;
        }
        public int CountUser()
        {
            return db.Users.Count();
        }
        public int CountOrder()
        {
            return db.Orders.Count();
        }

        public List<ReportViewModel> GetReport(DateTime? date)
        {

            //var model = from o in db.Orders
            //                                    join od in db.OrderDetails
            //                                    on o.ID equals od.OrderID


            //                                    select new ReportViewModel
            //                                    {
            //                                        OrderID = o.ID,
            //                                        ProductID = od.ProductID,

            //                                        Quantity = od.Quantity,
            //                                        Total = od.Quantity * od.Price,

            //                                        CustomerName = o.ShipName,
            //                                        CustomerAddress = o.ShipAddress,
            //                                        CustomerEmail = o.ShipEmail,
            //                                        CreateDate = o.CreateDate
            //                                    };
            //if(!string.IsNullOrEmpty(date.ToString()))
            //{
            //    model = model.Where(x => x.CreateDate.Value.Month.ToString("MMMM") == date.Value.Month.ToString("MMMM"));
            //}
            // return model.OrderByDescending(x => x.CreateDate).ToList();
            //string dateString = DateTime.ParseExact(date.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //string[] formats = { "MM/dd/yyyy" };
            
          // date = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
           // date?.ToString("yyyyMMdd");
            SqlParameter param = new SqlParameter("@DATE", date?.ToString("yyyyMMdd"));
           // object[] param = { new SqlParameter("@DATE", date?.ToString("yyyyMMdd")) };
            if(date==null)
            {
                param.Value = DBNull.Value;
            }
            var report = db.Database.SqlQuery<ReportViewModel>("EXEC RPT_RevenueByMonth @DATE", param).ToList();
            
            return report;
        }
    }
}
