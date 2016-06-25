//app-trips.js

(function () {

    "use strict";

    //Creating  the module

    angular.module("app-trips", ["simpleControls", "ngRoute"])
    .config(function($routeProvider){
        $routeProvider.when("/",{
            controller: "tripsController",
            controllerAs:"vm",
            templateUrl: "/Views/tripsView.html"
        });
        $routeProvider.when("/editor/:tripName", {
            controller: "tripEditorController",
            controllerAs: "vm",
            templateUrl: "/Views/tripEditorView.html"
        });

        $routeProvider.otherwise({redirectTo:"/"})
    });

    

})();