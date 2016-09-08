using System.Web.Mvc;

namespace Task2.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
           View("Error").ExecuteResult(ControllerContext);
        }
    }
}