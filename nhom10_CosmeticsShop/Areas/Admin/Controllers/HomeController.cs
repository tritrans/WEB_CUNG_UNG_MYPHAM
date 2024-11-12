using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nhom10_CosmeticsShop.Models;
using nhom10_CosmeticsShop.DBContext;


namespace nhom10_CosmeticsShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        public ActionResult Index()
        {
            if(Session["User"] == null)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            OrderDB orderDB = new OrderDB();
            ViewBag.pendingOrder = orderDB.GetOrders().Where(o => o.Status == "Đang chờ").ToList().Count;
            ViewBag.successOrder = orderDB.GetOrders().Where(o => o.Status == "Hoàn thành").ToList().Count;
            ViewBag.totalRevenue = orderDB.GetOrders().Where(o => o.Status == "Hoàn thành").Sum(o => o.TotalPayment);
            return View();
        }
    }
}