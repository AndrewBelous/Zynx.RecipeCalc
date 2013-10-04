using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Models
{
	public class Recipe
	{
		public string Name { get; set; }
		public List<RecipeItem> Ingredients { get; set; }
	}

	public class RecipeItem : Ingredient
	{
		public double IngredientAmount { get; set; }
	}
}	//n
