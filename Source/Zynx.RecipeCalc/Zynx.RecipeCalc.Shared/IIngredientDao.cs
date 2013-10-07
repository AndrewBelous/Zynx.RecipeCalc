using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Shared
{
	public enum IngredientType
	{
		Produce,
		Meat,
		Pantry
	}

	public interface IIngredientDao
	{
		int Id { get; set; }
		IngredientType MyType { get; set; }
		string Name { get; set; }
		decimal Price { get; set; }
		string Unit { get; set; }
		bool IsOrganic { get; set; }
	}	//i
}
