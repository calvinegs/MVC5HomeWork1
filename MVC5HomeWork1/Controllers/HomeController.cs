using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HomeWork1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult JSON(string id)
        {
            return Json(new
            {
                id = id,
                name = "Teacher Will",
                CreateOn = DateTime.Now
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CallService(string id)
        {
            //var idNum = Convert.ToInt32(id);
            //var StationService = new getStationStatus.Service1SoapClient("Service1Soap");
            //string color = StationService.getStationStatus(idNum);
            //return Json(color, JsonRequestBehavior.AllowGet);
            return Json(new { id = "000000" });
        }
    }
}