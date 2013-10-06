using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Data.Store;

namespace Zynx.RecipeCalc.Data.Access
{
	public class IngredientAccess
	{
		private IStore _store;

		/// <summary>
		/// Write-only property that must be initialized in order for this class to work
		/// </summary>
		public IStore Store
		{
			set { _store = value; }
		}

		public Objects.IngredientDao Get(int id)
		{
			return _store.Load<Objects.IngredientDao>(id);
		}

		public void Set(Objects.IngredientDao item)
		{
			_store.Store(item);
		}

		public void List()
		{
			
		}
	}	//c
}
