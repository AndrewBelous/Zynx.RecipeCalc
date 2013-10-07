using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Shared
{
	public interface IDataAccess<T>
	{
		T Get(int id);
		void Set(T item);
		IEnumerable<T> List();
	}	//i
}
