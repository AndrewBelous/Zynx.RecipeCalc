using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zynx.RecipeCalc.Data.Access;
using Zynx.RecipeCalc.Data.Objects;
using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/
		public ActionResult Index()
		{
			DataFiller.CheckData();

			return View();
		}

		

	}	//c

	internal class DataFiller
	{
		#region Hard-coded Data Objects
		private static List<IngredientDao> _ingredients = new List<IngredientDao>()
		{
			new IngredientDao()
			{
				Id = 1,
				IsOrganic = false,
				MyType = Shared.IngredientType.Produce,
				Name = "Lemon",
				Price = 2.03M,
			},
			new IngredientDao()
			{
				Id = 2,
				IsOrganic = false,
				MyType = Shared.IngredientType.Produce,
				Name = "Corn",
				Price = 0.87M,
				Unit = "Cup",
			},
			new IngredientDao()
			{
				Id = 3,
				IsOrganic = false,
				MyType = Shared.IngredientType.Meat,
				Name = "Chicken breast",
				Price = 2.19M,
			},
			new IngredientDao()
			{
				Id = 4,
				IsOrganic = false,
				MyType = Shared.IngredientType.Meat,
				Name = "Bacon",
				Price = 0.24M,
				Unit = "Slice",
			},
			new IngredientDao()
			{
				Id = 5,
				IsOrganic = false,
				MyType = Shared.IngredientType.Pantry,
				Name = "Pasta",
				Price = 0.31M,
				Unit = "Ounce",
			},
			new IngredientDao()
			{
				Id = 6,
				IsOrganic = true,
				MyType = Shared.IngredientType.Pantry,
				Name = "Olive Oil",
				Price = 1.92M,
				Unit = "Cup",
			},
			new IngredientDao()
			{
				Id = 7,
				IsOrganic = false,
				MyType = Shared.IngredientType.Pantry,
				Name = "Vinegar",
				Price = 1.26M,
				Unit = "Cup",
			},
			new IngredientDao()
			{
				Id = 8,
				IsOrganic = false,
				MyType = Shared.IngredientType.Pantry,
				Name = "Salt",
				Price = 0.16M,
				Unit = "Teaspoon",
			},
			new IngredientDao()
			{
				Id = 9,
				IsOrganic = false,
				MyType = Shared.IngredientType.Pantry,
				Name = "Pepper",
				Price = 0.17M,
				Unit = "Teaspoon",
			},
			new IngredientDao()
			{
				Id = 10,
				IsOrganic = true,
				MyType = Shared.IngredientType.Produce,
				Name = "Garlic",
				Price = 0.67M,
				Unit = "Clove",
			},
		};

		private static List<RecipeDao> _recipies = new List<RecipeDao>()
		{
			new RecipeDao() 
			{
				Id = 1,
				Name = "Recipe 1",
				Ingredients = new List<IngListItemDao>()
				{
					new IngListItemDao() { Id = 10, Amount = 1 },
					new IngListItemDao() { Id = 1, Amount = 1 },
					new IngListItemDao() { Id = 6, Amount = 0.75 },
					new IngListItemDao() { Id = 8, Amount = 0.75 },
					new IngListItemDao() { Id = 9, Amount = 0.5 },
				}
			},
			new RecipeDao() 
			{
				Id = 2,
				Name = "Recipe 2",
				Ingredients = new List<IngListItemDao>()
				{
					new IngListItemDao() { Id = 10, Amount = 1 },
					new IngListItemDao() { Id = 3, Amount = 4 },
					new IngListItemDao() { Id = 6, Amount = 0.5 },
					new IngListItemDao() { Id = 7, Amount = 0.5 },
				}
			},
			new RecipeDao() 
			{
				Id = 3,
				Name = "Recipe 3",
				Ingredients = new List<IngListItemDao>()
				{
					new IngListItemDao() { Id = 10, Amount = 1 },
					new IngListItemDao() { Id = 2, Amount = 4 },
					new IngListItemDao() { Id = 4, Amount = 4 },
					new IngListItemDao() { Id = 5, Amount = 8 },
					new IngListItemDao() { Id = 6, Amount = 0.3333333 },
					new IngListItemDao() { Id = 8, Amount = 1.25 },
					new IngListItemDao() { Id = 9, Amount = 0.75 },
				}
			},
		};
		#endregion

		public static void CheckData()
		{
			try
			{
				//check if recipe and ingredient data exists
				var recAcc = new RecipeAccess();
				var ingAcc = new IngredientAccess();

				var recs = recAcc.List();

				if (recs.Count() == 0)
				{
					foreach (var recipe in _recipies)
					{
						recAcc.Set(recipe);
					}
				}

				var ings = ingAcc.List();

				if (ings.Count() == 0)
				{
					foreach (var ingredient in _ingredients)
					{
						ingAcc.Set(ingredient);
					}
				}
			}
			catch (Exception ex)
			{
				//trace
				Trace.TraceError(ex.ToString());
			}
		}

	}	//c
}
