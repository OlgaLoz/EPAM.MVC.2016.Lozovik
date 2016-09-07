using System.Web;
using System.Web.Routing;

namespace Routing.Constraints
{
    public class EvenNumberConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            object val;
            values.TryGetValue(parameterName, out val);

            int number;
            if (!int.TryParse(val?.ToString(), out number))
            {
                return false;
            }

            return number % 2 == 0;
        }
    }
}