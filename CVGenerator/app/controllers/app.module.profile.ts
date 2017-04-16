﻿/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope', 'logger', 'profileService'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl',
                function ($scope, logger, profileService: Services.ProfileService) {

                    $scope.InitCreateProfile = () => {
                        $scope.ProfileId = null;

                        $scope.steps = [
                            'personalInformation',
                            'education',
                            'workExperience',
                            'skill',
                            'reference'
                        ];
                        $scope.step = $scope.steps[0];

                        $scope.Profile = {};
                        $scope.Educations = [];
                    }

                    $scope.SubmitPersonalInfo = () => {
                        var profile = $scope.Profile;
                        profileService.SubmitPersonalInfo(profile)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.ProfileId = response.data;
                                }
                            });
                    };

                    $scope.GotoPersonalInfo = () => {
                        $scope.step = 'personalInformation';
                    };

                    $scope.GotoWorkExp = () => {
                        $scope.step = 'workExperience';
                    };

                    $scope.GotoEducation = () => {
                        $scope.step = 'education';
                    };

                    $scope.GotoSkill = () => {
                        $scope.step = 'skill';
                    };

                    $scope.GotoRef = () => {
                        $scope.step = 'reference';
                    };

                    $scope.SubmitAcction = () => {
                        switch ($scope.step) {
                            case 'personalInformation': {
                                $scope.SubmitPersonalInfo();
                                break;
                            }
                            case 'education': {
                                $scope.SubmitEdus();
                                break;
                            }
                        }
                    }

                    $scope.AcctionStep = () => {
                        switch ($scope.step) {
                            case 'personalInformation': {
                                $scope.GotoPersonalInfo();
                                break;
                            }
                            case 'education': {
                                $scope.GotoEducation();
                                break;
                            }
                        }
                    };

                    $scope.PreviousStep = () => {
                        if ($scope.step == $scope.steps[0]) {
                            return;
                        }

                        for (var index = 0; index < $scope.steps.length; index++) {
                            if ($scope.step == $scope.steps[index]) {
                                $scope.step = $scope.steps[index - 1];
                                $scope.AcctionStep();
                                return;
                            }
                        }
                    };

                    $scope.NextStep = () => {
                        if ($scope.step == $scope.steps[$scope.steps.length - 1]) {
                            return;
                        }

                        for (var index = 0; index < $scope.steps.length; index++) {
                            if ($scope.step == $scope.steps[index]) {
                                $scope.step = $scope.steps[index + 1];
                                $scope.AcctionStep();
                                return;
                            }
                        }
                    };

                    $scope.AddEducation = () => {
                        $scope.Educations.push({
                            University: '',
                            FromYear: '',
                            ToYear: '',
                            Description: '',
                            IdProfile: $scope.ProfileId
                        });
                    };

                    $scope.RemoveEducation = (index) => {
                        $scope.Educations.splice(index, 1);
                    };

                    $scope.SubmitEdus = () => {
                        profileService.SubmitEdus($scope.Educations)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("OK");
                                }
                            });
                    };
                });
        }
    }
}