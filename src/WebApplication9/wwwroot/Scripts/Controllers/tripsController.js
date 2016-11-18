(function () {
    "use strict";
    angular.module("app-trips")
    .controller("tripsController", tripsController)

    function tripsController($http)
    {
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
        vm.trips=[];
        vm.newTrip = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        $http.get("/api/trips").then(function (response) {
            //success
            angular.copy(response.data, vm.trips);
        }, function (error) {
            //failture
            vm.errorMessage = "Failed to load data" + response.data;
        }).finally(function () {
            vm.isBusy = false;
        });


        vm.addTrip = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/trips", vm.newTrip)
            .then(function (response) {
                vm.trips.push(response.data);
                vm.newTrip = {};
            }, function () {
                vm.errorMessage = "Failed to save, error occured";
            }).finally(function () {
                vm.isBusy = false;
            });
        };
    }
})();