using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Zynx.RecipeCalc.Data.Access;
using Zynx.RecipeCalc.Data.Objects;
using Zynx.RecipeCalc.Domain.Logic;
using Zynx.RecipeCalc.Domain.Models;
using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Api.Controllers
{
	public class RecipesController : ApiController
	{
		IRecipeLogic _logic;

		public RecipesController() 
				: this(new RecipeLogic(new RecipeAccess(), new IngredientAccess()))
		{
		}

		public RecipesController(IRecipeLogic logic)
		{
			_logic = logic;
		}

		// GET api/recipe
		public IEnumerable<RecipeListItem> Get()
		{
			return _logic.List();
		}

		// GET api/recipe/5
		public Recipe Get(int id)
		{
			return _logic.Get(id);
		}
	}
}
