var ConfigFunction = function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider.when("/Persons", {
        templateUrl: "Person"
    });
    $routeProvider.when("/Translation/Add", {
        templateUrl: "Translation/Add"
    });
}