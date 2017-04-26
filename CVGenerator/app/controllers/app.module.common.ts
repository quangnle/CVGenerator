/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Common {
        public static $inject = ['$scope'];
        static Configure(module: angular.IModule) {
            module.controller('CommonCtrl', function ($scope) {

                $scope.ClearClientData = () => {                   
                    localStorage.clear();
                    window.location.href = "/";
                };
            })
        }
    }
}