using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Domain.Logic
{
	public class RecipeLogic : IRecipeLogic
	{
		private Strategies.ICalc _calc;
		private IDataAccess<IRecipeDao> _recipeData;
		private IDataAccess<IIngredientDao> _ingredientData;

		public RecipeLogic(IDataAccess<IRecipeDao> recipeData, 
				IDataAccess<IIngredientDao> ingredientData)
		{
			_recipeData = recipeData;
			_ingredientData = ingredientData;
			_calc = Strategies.CalcFactory.GetCalc();
		}

		public IList<Models.RecipeListItem> List()
		{
			var daList = _recipeData.List();
			var res = daList.Select<IRecipeDao, Models.RecipeListItem>(r => r.ToRecipeListItem());

			return res.ToList();
		}

		public Models.Recipe Get(int id)
		{
			var recipeDao = _recipeData.Get(id);
			var recipe = recipeDao.ToRecipe();

			//get ingredients
			for (int i = 0; i < recipe.Ingredients.Count; i++)
			{
				var ing = recipe.Ingredients[i];
				
				var ingDao = _ingredientData.Get(ing.Id);
				if (ingDao == null) continue;

				FillRecipeIngredient(ref ing, ingDao);
			}

			//calc
			recipe.Cost = _calc.CalculateCost(recipe);

			return recipe;
		}

		private void FillRecipeIngredient(ref Models.RecipeIngredient ing, IIngredientDao ingDao)
		{
			if (ing == null) return;
			if (ingDao == null) return;
			if (ing.Id != ingDao.Id) return;

			ing.IsOrganic = ingDao.IsOrganic;
			ing.MyType = ingDao.MyType;
			ing.Name = ingDao.Name;
			ing.Price = ingDao.Price;
			ing.Unit = ingDao.Unit;
		}
	}	//c

	/// <summary>
	/// Extensions class used for containing conversion methods
	/// </summary>
	public static class RecipeExtensions
	{
		public static Models.RecipeListItem ToRecipeListItem(this IRecipeDao input)
		{
			if (input == null) return null;

			var output = new Models.RecipeListItem()
			{
				Name = input.Name,
				Id = input.Id,
			};

			return output;
		}

		public static Models.Recipe ToRecipe(this IRecipeDao input)
		{
			if (input == null) return null;

			var output = new Models.Recipe()
			{
				Id = input.Id,
				Name = input.Name,
			};

			output.Ingredients = new List<Models.RecipeIngredient>();
			foreach (var ingDao in input.Ingredients)
			{
				var ing = new Models.RecipeIngredient();
				ing.Id = ingDao.Id;
				ing.IngredientAmount = ingDao.Amount;

				output.Ingredients.Add(ing);
			}

			return output;
		}
	}
}	//n
