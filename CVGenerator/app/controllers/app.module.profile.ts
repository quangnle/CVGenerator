/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl', function ($scope) {
                $scope.SubmitResume = () => {
                    // doing submit
                    alert('submitted');
                };
            })
        }
    }
}