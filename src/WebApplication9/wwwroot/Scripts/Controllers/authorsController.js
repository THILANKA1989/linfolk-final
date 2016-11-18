(function () {
    "use strict";
    angular.module("app-authors")
    .controller("authorsController", authorsController)

    function authorsController($http) {
        var vm = this;
        //vm.trips = [
        //    {
        //        name: "Us Trip",
        //        created: new Date()
        //    },
        //    {
        //        name: "UK TRIP",
        //        created: new Date()
        //    }
        //];
        vm.authors = [];
        vm.newAuthor = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        $http.get("/api/authors").then(function (response) {
            //success
            angular.copy(response.data, vm.authors);
        }, function (error) {
            //failture
            vm.errorMessage = "Failed to load data" + response.data;
        }).finally(function () {
            vm.isBusy = false;
        });


        vm.addAuthor = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/authors", vm.newAuthor)
            .then(function (response) {
                vm.authors.push(response.data);
                vm.newAuthor = {};
            }, function () {
                vm.errorMessage = "Failed to save, error occured";
            }).finally(function () {
                vm.isBusy = false;
            });
        };
    }
})();