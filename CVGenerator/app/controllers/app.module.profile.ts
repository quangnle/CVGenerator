/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope', 'logger', 'profileService'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl',
                function ($scope, logger, profileService: Services.ProfileService) {

                    $scope.InitCreateProfile = () => {
                        $scope.steps = [
                            'personalInformation',
                            'workExperience',
                            'skill',
                            'reference'
                        ];
                        $scope.step = $scope.steps[0];

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

                    $scope.PreviousStep = () => {
                        if ($scope.step == $scope.steps[0]) {
                            return;
                        }

                        for (var index = 0; index < $scope.steps.length; index++) {
                            if ($scope.step == $scope.steps[index]) {
                                $scope.step = $scope.steps[index - 1];
                                return;
                            }
                        }
                    };

                    $scope.NextStep = () => {
                        if ($scope.step == $scope.steps[$scope.steps.length - 1])
                        {
                            return;
                        }

                        for (var index = 0; index < $scope.steps.length; index++) {
                            if ($scope.step == $scope.steps[index])
                            {
                                $scope.step = $scope.steps[index + 1];
                                return;
                            }
                        }                     
                    };

                    $scope.AddEducation = () => {
                        $scope.Profile.Educations.push({ Id: Math.random(), University: '', FromYear: '', ToYear: '', Description: '' });
                    };

                    $scope.RemoveEducation = (index) => {
                        $scope.Profile.Educations.splice(index, 1);
                    };
                });
        }
    }
}