using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Data.Store
{
	public interface IStore
	{	
		T Load<T>(int id);
		void Store<T>(T item);
		void Delete<T>(T item);
	}	//i
}	//n
