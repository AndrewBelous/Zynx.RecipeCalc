//$(function()
//{
//	console.log("Controller loaded");
//});

function RecipeListCtrl($scope)
{
	$scope.recipies = [
	  {
	  	"Name": "Recipe 1",
	  	
	  },
	  {
	  	"Name": "Recipe 2",
	  	
	  },
	  {
	  	"Name": "Recipe 3",
	  	
	  }
	];
}

// angular bindings for app and controllers
var recipeCalcApp = angular.module('recipeCalcApp', []);
recipeCalcApp.controller('RecipeListCtrl', RecipeListCtrl);