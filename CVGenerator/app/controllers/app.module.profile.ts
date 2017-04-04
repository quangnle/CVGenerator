/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl', function ($scope) {
                $scope.SubmitProfile = () => {
                    alert('submitted');
                };

                $scope.GotoWorkExp = () => {
                    alert('submitted');
                };

                $scope.GotoEducation = () => {
                    // doing submit
                    alert('GotoEducation');
                };

                $scope.GotoSkill = () => {
                    // doing submit
                    alert('GotoSkill');
                };

                $scope.GotoRef = () => {
                    // doing submit
                    alert('GotoRef');
                };
            })
        }
    }
}