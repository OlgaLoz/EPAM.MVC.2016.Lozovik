using System.Web.Routing;
using Machine.Specifications;

namespace Routing.Tests
{
    [Subject("Default routes")]
    public class When_route_without_optional_id
    {
        private static RouteData routeData;

        Establish context = () => 
            routeData = new RouteData();

        Because of = () => 
            routeData = Helper.GetRouteData("~/Home/Index");

        It should_be_Home_Index = () =>
            Helper.CompareResults(routeData, "Home", "Index").ShouldBeTrue();
    }

    [Subject("Default routes")]
    public class When_route_with_custom_optional_id
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () =>
            routeData = Helper.GetRouteData("~/Home/Index/6");

        It should_be_Home_Index_6 = () =>
            Helper.CompareResults(routeData, "Home", "Index", "6").ShouldBeTrue();
    }

    [Subject("Static routes")]
    public class When_route_has_even_int_id_in_range_from_1_to_100_and_httpMethod_get
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () =>
            routeData = Helper.GetRouteData("~/Static/6");

        It should_be_Home_Index_6 = () =>
            Helper.CompareResults(routeData, "Home", "Index", "6").ShouldBeTrue();
    }

    [Subject("Static routes: custom attribute")]
    public class When_route_has_odd_id
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () => 
            routeData = Helper.GetRouteData("~/Static/5");

        It should_not_be_Home_Index_5 = () =>
            Helper.CompareResults(routeData, "Home", "Index", "5").ShouldBeFalse();
    }

    [Subject("Static routes: constraints")]
    public class When_route_has_not_int_id
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () =>
            routeData = Helper.GetRouteData("~/Static/qwerty");

        It should_not_be_Home_Index_qwerty = () =>
            Helper.CompareResults(routeData, "Home", "Index", "qwerty").ShouldBeFalse();
    }

    [Subject("Static routes: constraints")]
    public class When_route_has_id_not_in_range_from_1_to_100
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () =>
            routeData = Helper.GetRouteData("~/Static/116");

        It should_not_be_Home_Index_116 = () =>
            Helper.CompareResults(routeData, "Home", "Index", "116").ShouldBeFalse();
    }

    [Subject("Static routes: constraints")]
    public class When_route_has_not_get_httpMethod
    {
        private static RouteData routeData;

        Establish context = () =>
            routeData = new RouteData();

        Because of = () =>
            routeData = Helper.GetRouteData("~/Static/2", "POST");

        It should_not_be_Home_Index_2 = () =>
            Helper.CompareResults(routeData, "Home", "Index", "2").ShouldBeFalse();
    }
}
