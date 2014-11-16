var myApp = angular.module('app', []);

myApp.factory('TeaService', [
    '$http', function($http) {
        return {
            GetTeaBases: function () {
                return $http.get("/teastall/GetTeaBases");
            },
            GetFlavors: function () {
                return $http.get("/teastall/GetFlavors");
            },
            GetToppings: function () {
                return $http.get("/teastall/GetToppings");
            }
        }
    }
]);