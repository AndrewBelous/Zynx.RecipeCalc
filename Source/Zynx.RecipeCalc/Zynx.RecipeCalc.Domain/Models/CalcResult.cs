using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynx.RecipeCalc.Domain.Models
{
	public class CalcResult
	{
		public decimal Tax { get; set; }
		public string TaxDisp { get { return Tax.ToString("C"); } }
		public decimal Discount { get; set; }
		public string DiscountDisp { get { return Discount.ToString("C"); } }
		public decimal Total { get; set; }
		public string TotalDisp { get { return Total.ToString("C"); } }

	}	//c
}	//n
