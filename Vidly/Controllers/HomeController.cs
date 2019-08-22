using System;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous] //Load First Page allow anonymous
    public class HomeController : Controller
    {
        [OutputCache(Duration =0,VaryByParam ="*",NoStore =true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}