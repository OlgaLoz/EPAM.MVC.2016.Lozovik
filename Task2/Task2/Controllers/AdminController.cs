using System.Web.Mvc;
using Task2.Infrastructure;

namespace Task2.Controllers
{  
    public class AdminController : BaseController
    {
        // first version of CustomActionInvoker (implements IActionInvocer)
        public AdminController()
        {
            ActionInvoker = new CustomActionInvoker();    
        }

        //  second version of CustomActionInvoker (extends ActionMethodSelectorAttribute)
        //  [Local]
        [ActionName("User-List")]
        public ActionResult UserList()
        {
            return View(Repository.Users);
        }

        //  second version of CustomActionInvoker (extends ActionMethodSelectorAttribute)
        //  [Local]
        public ActionResult DeleteUser(int id)
        {
            Repository.Delete(id);
            return View("User-List", Repository.Users);
        }
    }
}