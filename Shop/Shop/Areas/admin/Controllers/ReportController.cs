using Microsoft.Reporting.WebForms;
using Models.DAO;
using Models.Model;
using Models.ViewModel;
using Shop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Shop.Areas.admin.Controllers
{
    public class ReportController : Controller
    {
        // GET: admin/Report
        public ActionResult Index(DateTime? date)
        {
            //ReportViewer report = new ReportViewer();
            //report.ProcessingMode = ProcessingMode.Local;
            //report.SizeToReportContent = true;
            //report.Width = Unit.Percentage(900);
            //report.Height = Unit.Percentage(900);

            //report.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\RPT_Revenue.rdlc";

            //SqlParameter date = new SqlParameter("@DATE", filter.datetime);

            //var res = db.Database.SqlQuery("RPT_RevenueByMonth @DATE", date).SingleOrDefault();

            //report.LocalReport.DataSources.Add(new ReportDataSource("ModelDbContext", res));
            ////IEnumerable ts = db.sel("7/5/2020");
            ////report.LocalReport.DataSources.Add(new ReportDataSource("ShopDataSet",ts));

            //ViewBag.Report = report;
            var report = new ReportDao().GetReport(date);
            return View(report);
        }
        ModelDbContext db = new ModelDbContext();
        public ActionResult ReportRevenueByMonth(ReportFilter filter)
        {
            
            return View();
        }

        
        public ActionResult Export()
        {
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            return View();
        }
    }
}