using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.App_Services;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class BuyController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View(CarsDatabase.getCars());
        }

        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = CarsDatabase.getCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult Purchase(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsDatabase.deleteCar(id);
            return View();
        }
    }
}