using System.Web.Mvc;
using Task3.Repository;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Person", CustomRepository.User.Side);
        }

        [HttpGet]
        public ActionResult GetFooter()
        {
            return PartialView("_Footer");
        }
    }
}