/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Resume {
        public static $inject = ['$scope'];

        static Configure(module: angular.IModule) {
            module.controller('ResumeCtrl', function ($scope) {
                $scope.SubmitResume = () => {
                    alert("ád");
                };
            })
        }
    }
}