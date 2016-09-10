using System.Web.Mvc;
using Task4.Models;

namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            var model = new Person();

            if (TryUpdateModel(model))
            {
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateFromQuery()
        {
            var model = new Person();

            if (TryUpdateModel(model, new QueryStringValueProvider(ControllerContext)))
            {
                return View("Create", model);
            }

            return View("Create");
        }
    }
}