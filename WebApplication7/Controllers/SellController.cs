using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.App_Services;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellCar(Car car)
        {
            if (ModelState.IsValid)
            {
                CarsDatabase.addCar(car);
                return View();
            }
            return View("Index");
        }
    }
}