/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Resume {
        public static $inject = ['$scope', 'templateService'];

        static Configure(module: angular.IModule) {
            module.controller('ResumeCtrl', function ($scope, templateService: Services.TemplateService) {
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