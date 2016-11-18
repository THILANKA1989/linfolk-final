(function () {
    "use strict";
    angular.module("app-category")
    .controller("categoryController", categoryController)

    function categoryController($http) {
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
        vm.category = [];
        vm.newCategory = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        $http.get("/api/category").then(function (response) {
            //success
            angular.copy(response.data, vm.category);
        }, function (error) {
            //failture
            vm.errorMessage = "Failed to load data" + response.data;
        }).finally(function () {
            vm.isBusy = false;
        });


        vm.addCategory = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/category", vm.newCategory)
            .then(function (response) {
                vm.category.push(response.data);
                vm.newCategory = {};
            }, function () {
                vm.errorMessage = "Failed to save, error occured";
            }).finally(function () {
                vm.isBusy = false;
            });
        };
    }
})();