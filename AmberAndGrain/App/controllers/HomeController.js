app.controller("HomeController", ["$scope", "$http",
    function ($scope, $http) {
        $scope.message = "Dees Recipees:";

        $http.get("/api/recipes").then(function (result) {
            $scope.recipes = result.data;
        });
    }
]);