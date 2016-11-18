(function () {
    angular.module("app-category", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "categoryController",
            controllerAs: "vm",
            templateUrl: "/views/categoryView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });
})();