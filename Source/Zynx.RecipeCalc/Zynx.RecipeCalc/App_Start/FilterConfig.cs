using System.Web;
using System.Web.Mvc;

namespace Zynx.RecipeCalc
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}