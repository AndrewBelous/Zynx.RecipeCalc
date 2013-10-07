using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Data.Store;
using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Data.Access
{
	public class RecipeAccess : DataAccessBase<IRecipeDao>
	{
		public override IRecipeDao Get(int id)
		{
			return Store.Load<Objects.RecipeDao>(id);
		}

		public override void Set(IRecipeDao item)
		{
			Store.Store((Objects.RecipeDao)item);
		}

		public override IEnumerable<IRecipeDao> List()
		{
			return Store.List<Objects.RecipeDao>();
		}
	}	//c
}
