(function () {
    "use strict";
    angular.module("app-posts")
    .controller("postsController", postsController)

    function postsController($http) {
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
        vm.posts = [];
        vm.newPost = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        $http.get("/api/posts").then(function (response) {
            //success
            angular.copy(response.data, vm.posts);
        }, function (error) {
            //failture
            vm.errorMessage = "Failed to load data" + response.data;
        }).finally(function () {
            vm.isBusy = false;
        });


        vm.addPost = function () {
            vm.isBusy = true;
            vm.errorMessage = "";
            $http.post("/api/posts", vm.newPost)
            .then(function (response) {
                vm.posts.push(response.data);
                vm.newTrip = {};
            }, function () {
                vm.errorMessage = "Failed to save, error occured";
            }).finally(function () {
                vm.isBusy = false;
            });
        };
    }
})();