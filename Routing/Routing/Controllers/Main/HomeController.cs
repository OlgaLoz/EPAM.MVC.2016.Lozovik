using System.Web.Mvc;

namespace Routing.Controllers.Main
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string id = RouteData.Values["id"]?.ToString();
            ViewBag.Message = id ?? "<no id>";
            return View();
        }
    }
}