using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zynx.RecipeCalc.Api.Controllers
{
	public class RecipesController : ApiController
	{
		// GET api/recipe
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/recipe/5
		public string Get(int id)
		{
			return "value";
		}
	}
}
