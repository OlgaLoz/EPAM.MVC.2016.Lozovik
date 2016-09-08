using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Task2.Controllers;

namespace Task2.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (StringComparer.InvariantCultureIgnoreCase.Compare(controllerName, "Customer") == 0)
            {
                return (IController)DependencyResolver.Current.GetService(typeof(UserController));
            }

            return base.CreateController(requestContext, controllerName);
        }

        //sessionless controller via CustomControllerFactory
        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(HomeController))
            {
                return SessionStateBehavior.Disabled;
            }

            return base.GetControllerSessionBehavior(requestContext, controllerType);
        }
    }
}