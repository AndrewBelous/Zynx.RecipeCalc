using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Models
{
	public class Recipe : RecipeListItem
	{
		public List<RecipeIngredient> Ingredients { get; set; }
		public CalcResult Cost { get; set; }
	}

	public class RecipeListItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class RecipeIngredient : Ingredient
	{
		public string DisplayName 
		{
			get 
			{
				string name = IngredientAmount.ToString("0.##") + " " + 
					(!string.IsNullOrWhiteSpace(Unit) ? Unit + " of " : string.Empty) +
					(IsOrganic ? " Organic " : string.Empty) +
					Name;

				return name;
			}
		}
		public double IngredientAmount { get; set; }
	}
}	//n
