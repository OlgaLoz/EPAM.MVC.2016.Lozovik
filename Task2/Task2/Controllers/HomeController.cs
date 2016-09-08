using System.Web.Mvc;

namespace Task2.Controllers
{
    // sessionless controller via
    // [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}