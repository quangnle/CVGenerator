/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class UserResume {
        public static $inject = ['$scope', 'templateService'];

        static Configure(module: angular.IModule) {
            module.controller('UserResumeCtrl', function ($scope, templateService: Services.TemplateService) {

                $scope.InitViewUserProfile = (data) => {
                    $scope.TemplateSrc = data.Template.TemplateSrc;
                    $scope.TemplateSrcIndex = data.Template.TemplateSrc + 'index.html';
                    $scope.PersonalInformation = data.PersonalInformation;
                    $scope.Educations = data.Educations;
                    $scope.WorkExps = data.WorkExps;
                    $scope.Skills = data.Skills;
                    $scope.References = data.References;
                }

            })
        }
    }
}