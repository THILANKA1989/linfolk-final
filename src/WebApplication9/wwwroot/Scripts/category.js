(function () {
    angular.module("app-category", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "categoryController",
            controllerAs: "vm",
            templateUrl: "/views/categoryView.html"
        });

        $routeProvider.when("/edit", {
            controller: "categoryEditorController",
            controllerAs: "vm",
            templateUrl: "/views/categoryEditorView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });
})();