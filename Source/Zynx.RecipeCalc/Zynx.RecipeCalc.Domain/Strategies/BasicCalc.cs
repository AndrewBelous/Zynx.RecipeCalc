using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Strategies
{
	public class BasicCalc : ICalc
	{
		private static decimal DISCOUNT_PERCENT = 0.05M;
		private static decimal TAX_RATE = 0.086M;

		#region ICalc Members

		public Models.CalcResult CalculateCost(Models.Recipe recipe)
		{
			//test inputs
			if (recipe == null) 
				throw new ArgumentNullException("recipe");
			if (recipe.Ingredients == null || !recipe.Ingredients.Any()) 
				throw new ArgumentOutOfRangeException("recipe.Ingredients");
			
			var result = new Models.CalcResult();

			//get rawtotal
			decimal rawTotal = recipe.Ingredients.Sum(t => (t.Price * (decimal)t.IngredientAmount));
			//get discount
			result.Discount = recipe.Ingredients.Where(t => t.IsOrganic)
					.Sum(r => ((r.Price * (decimal)r.IngredientAmount) * DISCOUNT_PERCENT));
			//get sales tax
			result.Tax = recipe.Ingredients.Where(t => t.MyType != Models.IngredientType.Produce)
					.Sum(r => ((r.Price * (decimal)r.IngredientAmount) * TAX_RATE));
			//set total
			result.Total = rawTotal - result.Discount + result.Tax;

			return result;
		}

		#endregion
	}	//c
}	//n
