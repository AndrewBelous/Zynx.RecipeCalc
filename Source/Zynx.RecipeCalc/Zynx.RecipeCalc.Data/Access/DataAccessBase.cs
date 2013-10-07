using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Data.Store;
using Zynx.RecipeCalc.Shared;

namespace Zynx.RecipeCalc.Data.Access
{
	public abstract class DataAccessBase<T> : IDataAccess<T>
	{
		private IStore _store;

		public IStore Store
		{
			get { return _store; }
		}

		public DataAccessBase()
		{
			_store = StoreFactory.GetStore();
		}

		#region IDataAccess<T> Members
		public abstract T Get(int id);
		public abstract void Set(T item);
		public abstract IList<T> List();
		#endregion
	}	//c
}
