using System.Web.Mvc;

namespace RoboEval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "RoboEval";

            return View();
        }
    }
}
