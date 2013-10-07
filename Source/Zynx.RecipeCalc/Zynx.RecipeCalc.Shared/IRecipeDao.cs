using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Shared
{
	public interface IRecipeDao
	{
		int Id { get; set; }
		string Name { get; set; }
		IEnumerable<IngListItemDao> Ingredients { get; set; }
	}	//i

	public class IngListItemDao
	{
		public int Id { get; set; }
		public double Amount { get; set; }
	}
}
