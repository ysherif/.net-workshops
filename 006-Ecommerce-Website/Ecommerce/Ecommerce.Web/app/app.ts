module Ecommerce {

    class RoutingConfiguration
    {
        constructor($routerProvider: ng.route.IRouteProvider) {
            $routerProvider
                .when("/", {
                    templateUrl: "/app/home/home.html",
                    controller: "homeCtrl as vm"
                })
                .when("/about", {
                    templateUrl: "/app/About/about.html",
                    controller: "aboutCtrl as vm"
                })
                .when("/contact", {
                    templateUrl: "/app/Contact/contact.html",
                    controller: "contactCtrl as vm"
                })
                .otherwise({ redirectTo: '/' });
        }
    }

    RoutingConfiguration.$inject = ['$routeProvider'];
    var ecommerceApp = angular.module('ecommerce', ['ngRoute']);
    ecommerceApp.config(RoutingConfiguration);
}


