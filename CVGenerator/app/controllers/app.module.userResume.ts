/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class UserResume {
        public static $inject = ['$scope', 'templateService'];

        static Configure(module: angular.IModule) {
            module.controller('UserResumeCtrl', function ($scope, templateService: Services.TemplateService) {
                $scope.InitViewProfile = (data) => {
                    templateService.GetAll()
                        .then((response) => {
                            if (response.status == 200) {
                                $scope.Templates = response.data;
                            }
                        });
                }
            })
        }
    }
}