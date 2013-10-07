using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Shared;

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
			rawTotal = Math.Round(rawTotal, 2, MidpointRounding.AwayFromZero);

			//get discount
			result.Discount = recipe.Ingredients.Where(t => t.IsOrganic)
					.Sum(r => ((r.Price * (decimal)r.IngredientAmount) * DISCOUNT_PERCENT));
			
			decimal tax = recipe.Ingredients.Where(t => t.MyType != IngredientType.Produce)
					.Sum(r => ((r.Price * (decimal)r.IngredientAmount) * TAX_RATE));
			//get sales tax
			result.Tax = RoundTaxToSeven(tax);
			
			//set total
			result.Total = rawTotal - result.Discount + result.Tax;

			return result;
		}

		#endregion

		private decimal RoundTaxToSeven(decimal tax)
		{
			//round to 2 decimals to start
			tax = Math.Round(tax, 2);
			int large = (int)(tax * 100);

			//check if divisible by 7
			while (large % 7 != 0)
			{
				//increment by 1
				large++;
			} 

			decimal res = (decimal)large / 100;

			return res;
		}
	}	//c
}	//n
