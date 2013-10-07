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
		List<int> Ingredients { get; set; }
	}	//i
}
