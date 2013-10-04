using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Strategies
{
	public interface ICalc
	{
		Models.CalcResult CalculateCost(Models.Recipe recipe);
	}	//i
}	//n
