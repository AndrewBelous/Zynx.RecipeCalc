
function RecipeListCtrl($scope, $http)
{
	$http.get('api/recipes').success(function (data)
	{
		$scope.recipes = data;
	});

	$scope.viewDetails = function (recipeId)
	{
		$http.get('api/recipes/' + recipeId).success(function (data)
		{
			for( var i = 0; i < $scope.recipes.length; i++)
			{
				//find the correct recipe object
				if ($scope.recipes[i].Id == recipeId)
				{
					$scope.recipes[i] = data;
					break;
				}
			}
		});
	}

}

// angular bindings for app and controllers
var recipeCalcApp = angular.module('recipeCalcApp', []);
recipeCalcApp.controller('RecipeListCtrl', RecipeListCtrl);