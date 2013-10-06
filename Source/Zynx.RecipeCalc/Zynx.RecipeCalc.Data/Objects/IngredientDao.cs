using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Data.Objects
{
	public enum IngredientType
	{
		Produce,
		Meat,
		Pantry
	}

	public class IngredientDao
	{
		public int Id { get; set; }
		public IngredientType MyType { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Unit { get; set; }
		public bool IsOrganic { get; set; }

		/// <summary>
		/// Usefull for debugging. Very easy to see in intellisense what the object contains
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "{ \"Id\": \"" + Id + "\", \"Name\": \"" + Name + "\" }";
		}
	}	//c
}
