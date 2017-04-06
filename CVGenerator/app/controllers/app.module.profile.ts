/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope', 'logger', 'profileService'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl', function ($scope, logger, profileService: Services.ProfileService) {

                $scope.InitCreateProfile = () => {
                    $scope.Profile = {};
                    $scope.Profile.Educations = [];
                }

                $scope.SubmitProfile = () => {
                    // doing submit
                    var profile = $scope.Profile;
                    profileService.SubmitProfile(profile)
                        .then((response) => {
                            if (response.status == 200) {
                                logger.log("OK");
                            }
                        });
                    //alert('submitted');
                };

                $scope.GotoWorkExp = () => {
                    logger.log("asdads");
                    // doing submit
                    //  alert('submitted');
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

                $scope.AddEducation = () => {
                    $scope.Profile.Educations.push({ University: '', FromYear: '', ToYear: '' });
                };
            })
        }
    }
}