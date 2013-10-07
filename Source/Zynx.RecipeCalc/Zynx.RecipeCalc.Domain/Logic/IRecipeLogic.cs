using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Logic
{
	public interface IRecipeLogic
	{
		IList<Models.RecipeListItem> List();
		Models.Recipe Get(int id);
	}
}
