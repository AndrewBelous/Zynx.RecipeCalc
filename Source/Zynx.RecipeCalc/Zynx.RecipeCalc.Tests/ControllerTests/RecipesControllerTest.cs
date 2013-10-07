using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zynx.RecipeCalc.Api.Controllers;

namespace Zynx.RecipeCalc.Tests.ControllerTests
{
	[TestClass]
	public class RecipesControllerTest
	{
		[TestMethod]
		public void TestInit()
		{	
			var logic = new Mocks.RecipeLogicMock();
			var controller = new RecipesController(logic);

			Assert.IsNotNull(controller);
		}

		[TestMethod]
		public void TestList()
		{
			var logic = new Mocks.RecipeLogicMock();
			var controller = new RecipesController(logic);

			Assert.IsNotNull(controller);

			var res = controller.Get();

			Assert.IsNotNull(res);
			Assert.IsInstanceOfType(res, typeof(List<Domain.Models.RecipeListItem>));
		}

		[TestMethod]
		public void TestGet()
		{
			var logic = new Mocks.RecipeLogicMock();
			var controller = new RecipesController(logic);

			Assert.IsNotNull(controller);

			var res = controller.Get(2);

			Assert.IsNotNull(res);
			Assert.IsInstanceOfType(res, typeof(Domain.Models.Recipe));
			Assert.IsTrue(res.Id == 2);
			Assert.IsTrue(res.Name == "Test Recipe");

		}
	}
}
