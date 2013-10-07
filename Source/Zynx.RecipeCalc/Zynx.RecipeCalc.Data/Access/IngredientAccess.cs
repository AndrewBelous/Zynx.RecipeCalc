using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Data.Store;
using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Data.Access
{
	public class IngredientAccess : DataAccessBase<IIngredientDao>
	{
		public override IIngredientDao Get(int id)
		{
			return Store.Load<Objects.IngredientDao>(id);
		}

		public override void Set(IIngredientDao item)
		{
			Store.Store((Objects.IngredientDao)item);
		}

		public override IList<IIngredientDao> List()
		{
			return (IList<IIngredientDao>)Store.List<Objects.IngredientDao>();
		}
	}	//c
}
