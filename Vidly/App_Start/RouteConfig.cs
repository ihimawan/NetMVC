using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//enable attribute routing, to use 'annotations' instead.
			routes.MapMvcAttributeRoutes(); 

			/*//If you do not use attribute routing, you do this.
			routes.MapRoute(
				"MoviesByReleaseDate",
				"movies/released/{year}/{month}",
				new { controller = "Movies", action = "ByReleaseDate"}, //default things 
				new { year = @"\d{4}", month = @"\d{2}|\d{1}" } //contraints 
			);
			*/

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
