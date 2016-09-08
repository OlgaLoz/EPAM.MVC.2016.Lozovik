using System.Threading.Tasks;
using System.Web.Mvc;
using Task2.Infrastructure;
using Task2.Models;

namespace Task2.Controllers
{
    public class UserController : BaseController
    {
        [ActionName("Add-User")]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [ActionName("Add-User")]
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            await Repository.Add(user);         
            return View("User-List", Repository.Users);
        }

        [ActionName("User-List")]
        [HttpGet]
        public ActionResult UserList()
        {
            return View(Repository.Users);
        }

        [ActionName("User-List")]
        [HttpPost]
        public JsonResult UserListJson()
        {
            return Json(Repository.Users);
        }
    }
}