﻿/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$scope', '$location', 'logger', 'profileService', 'skillService'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl',
                function ($scope, $location, logger, profileService: Services.ProfileService, skillService: Services.SkillService) {

                    $scope.InitCreateProfile = () => {
                        $scope.steps = [
                            'personalInformation',
                            'education',
                            'workExperience',
                            'skill',
                            'reference'
                        ];
                        $scope.step = $scope.steps[0];

                        var tokens = $location.$$path.split("/");
                        var id = tokens[3];
                        if (id == null) {
                            $scope.ProfileId = null;
                            $scope.Profile = {};
                            $scope.Educations = [];
                            $scope.Skills = [];
                            $scope.References = [];
                            $scope.WorkExps = [];
                        }
                        else {
                            profileService.GetProfile(id)
                                .then((response) => {
                                    if (response.status == 200) {
                                        var res = <any>response.data;
                                        $scope.ProfileId = res.PersonalInformation.Id;

                                        $scope.ProfileGuidId = res.PersonalInformation.IdProfile;
                                        $scope.Profile = res.PersonalInformation;
                                        $scope.Educations = res.Educations;
                                        $scope.Skills = res.Skills;
                                        $scope.WorkExps = res.WorkExps;
                                        $scope.References = res.References;
                                    }
                                });
                        }
                    }

                    $scope.SubmitPersonalInfo = () => {
                        var profile = $scope.Profile;
                        profileService.SubmitPersonalInfo(profile)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.ProfileId = (<any>response.data).Id;

                                    $scope.ProfileGuidId = (<any>response.data).GuidId;
                                    $location.path($location.$$path + $scope.ProfileGuidId);
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
                            case 'skill': {
                                $scope.SubmitSkills();
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

                    // education
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
                                    logger.log("Saved successfully.");
                                }
                            });
                    };

                    // skills
                    $scope.AddSkill = () => {
                        $scope.Skills.push({
                            Name: '',
                            Score: 1,
                            IdProfile: $scope.ProfileId
                        });
                    };

                    $scope.RemoveSkill = (index) => {
                        $scope.Skills.splice(index, 1);
                    };

                    $scope.SubmitSkills = () => {
                        skillService.SubmitSkills($scope.Skills)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                }
                            });
                    };


                    //work experience
                    $scope.RemoveWorkExp = (index) => {
                        $scope.WorkExps.splice(index, 1);
                    };

                    $scope.AddWorkExp = () => {
                        $scope.WorkExps.push({
                            Company: '',
                            FromMonth: '',
                            FromYear: '',
                            ToMonth: '',
                            ToYear: '',
                            Position: '',
                            Description: '',
                            IdProfile: $scope.ProfileId
                        });
                    };
                });
        }
    }
}