using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Data.Store
{
	public class StoreFactory
	{
		/// <summary>
		/// Potentially, this method would retrieve a store from a list of 
		/// available ones. Since right now we are only using one data store,
		/// this abstraction is enough to allow later additions without changes
		/// in code elsewhere.
		/// </summary>
		/// <returns></returns>
		public static IStore GetStore()
		{
			return new RavenStore();
		}
	}
}
