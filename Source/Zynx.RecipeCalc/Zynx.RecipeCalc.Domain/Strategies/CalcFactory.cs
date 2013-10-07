using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Strategies
{
	public class CalcFactory
	{
		public static ICalc GetCalc()
		{
			return new BasicCalc();
		}
	}	//c
}
