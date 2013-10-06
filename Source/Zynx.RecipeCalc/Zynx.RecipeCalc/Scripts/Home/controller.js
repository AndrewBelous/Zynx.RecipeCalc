//$(function()
//{
//	console.log("Controller loaded");
//});

function RecipeListCtrl($scope, $http)
{
	$http.get('api/recipes').success(function (data)
	{
		$scope.recipes = data;
	});
}

// angular bindings for app and controllers
var recipeCalcApp = angular.module('recipeCalcApp', []);
recipeCalcApp.controller('RecipeListCtrl', RecipeListCtrl);