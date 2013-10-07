using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zynx.RecipeCalc.Domain.Logic;

namespace Zynx.RecipeCalc.Tests.Mocks
{
	public class RecipeLogicMock : IRecipeLogic
	{
		#region IRecipeLogic Members

		public IList<Domain.Models.RecipeListItem> List()
		{
			return new List<Domain.Models.RecipeListItem>()
			{
				new Domain.Models.RecipeListItem()
				{
					Id = 1,
					Name = "Recipe 1"
				},
				new Domain.Models.RecipeListItem()
				{
					Id = 2,
					Name = "Recipe 2"
				},
				new Domain.Models.RecipeListItem()
				{
					Id = 3,
					Name = "Recipe 3"
				},
			};
		}

		public Domain.Models.Recipe Get(int id)
		{
			return new Domain.Models.Recipe()
			{
				Id = id,
				Name = "Test Recipe"
			};
		}

		#endregion
	}	//c
}
