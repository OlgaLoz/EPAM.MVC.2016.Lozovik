using System.Web.Mvc;

namespace Task2.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (controllerContext.RequestContext.HttpContext.Request.IsLocal)
            {
                new ControllerActionInvoker().InvokeAction(controllerContext, actionName);
                return true;
            }

            return false;
        }
    }
}
