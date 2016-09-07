using System;
using System.Web;
using System.Web.Routing;
using Moq;

namespace Routing.Tests
{
    public static class Helper
    {
        public static RouteData GetRouteData(string url, string httpMethod = "GET")
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            httpContext.Setup(x => x.Request.HttpMethod).Returns(httpMethod);

            return routes.GetRouteData(httpContext.Object);
        }

        public static bool CompareResults(RouteData routeData, string controller, string action, string id = null)
        {
            var isIdMatch = true;

            if (id != null)
            {
                isIdMatch = Compare(routeData.Values["id"].ToString(), id);
            }

            return isIdMatch &&
                   Compare(routeData.Values["controller"].ToString(), controller) &&
                   Compare(routeData.Values["action"].ToString(), action);
        }

        private static bool Compare(string a, string b) =>
            StringComparer.InvariantCultureIgnoreCase.Compare(a, b) == 0;

    }
}