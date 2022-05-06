using EcommerceWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWeb.Controllers
{
    public class HomeController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        public ActionResult Index()
        {
            return View(db.MatHangs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string product)
        {
            EcommerceContext entities = new EcommerceContext();
            return View(entities.MatHangs.Where(x => x.TenMH.Contains(product.ToLower())).ToList());
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

        public ActionResult Man()
        {
            var manProduct = db.MatHangs.Where(x => x.Gender == 1).ToList();
            return View(manProduct);
        }

        public ActionResult Woman()
        {
            var womanProduct = db.MatHangs.Where(x => x.Gender == 0).ToList();
            return View(womanProduct);
        }
    }
}