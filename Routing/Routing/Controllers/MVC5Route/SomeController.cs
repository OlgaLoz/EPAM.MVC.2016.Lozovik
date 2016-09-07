using System.Web.Mvc;

namespace Routing.Controllers.MVC5Route
{
    public class SomeController : Controller
    {
        [Route("Main")]
        public ActionResult Index()
        {
            ViewBag.Message = "Route: Main";
            return View();
        }

        [Route("Main/Create/{id:int}")]
        public ActionResult Add()
        {
            ViewBag.Message = "Route: Main/Create/{id}" + $" id :{RouteData.Values["id"]}";
            return View("Index");
        }

        [Route("Main/Optional/{id?}")]
        public ActionResult Optional()
        {
            string id = RouteData.Values["id"]?.ToString();
            ViewBag.Message = id ?? "<no id>";
            return View("Index");
        }


    }
}