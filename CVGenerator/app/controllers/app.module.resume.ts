/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Resume {
        public static $inject = ['$scope', 'profileService'];

        static Configure(module: angular.IModule) {
            module.controller('ResumeCtrl', function ($scope, profileService: Services.ProfileService) {
                $scope.SubmitResume = () => {                  
                
                };
            })
        }
    }
}