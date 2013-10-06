using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Data.Objects
{
	public class RecipeDao
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<int> Ingredients { get; set; }
	}	//c
}	//n
