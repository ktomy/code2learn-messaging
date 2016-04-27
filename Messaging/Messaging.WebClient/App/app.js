var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule']);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        controller: "indexController",
        templateUrl: "index.html"
    })

    .when("/login", {
        controller: "loginController",
        templateUrl: "app/views/login.html"
    })

    .otherwise({ redirectTo: "/home" });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

