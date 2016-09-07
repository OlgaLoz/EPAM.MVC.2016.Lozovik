using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Routing.Constraints;

namespace Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           //static & constraint & compound
            routes.MapRoute(
                name: "Static",
                url: "Static/{id}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "Routing.Controllers.Additional" },
                constraints: new
                {
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                    {
                        new IntRouteConstraint(),
                        new RangeRouteConstraint(0, 100),
                        new EvenNumberConstraint()
                    }),
                    httpMethod = new HttpMethodConstraint("GET")
                }
            );

            //default routes & custom segment & optional
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Routing.Controllers.Main" }
            );
        }
    }
}
