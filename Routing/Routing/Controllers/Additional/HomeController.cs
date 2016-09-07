using System.Web.Mvc;

namespace Routing.Controllers.Additional
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id)
        {
            var json = $"Static route, even integer id in range [0, 100]: {id}";
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}