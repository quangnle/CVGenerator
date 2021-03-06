﻿/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    export class Profile {
        public static $inject = ['$rootScope', '$scope', '$location', 'logger', 'profileService', 'skillService', 'workExpService', 'referenceService', 'uploadService'];

        static Configure(module: angular.IModule) {
            module.controller('ProfileCtrl',
                function ($rootScope, $scope, $location, logger,
                    profileService: Services.ProfileService,
                    skillService: Services.SkillService,
                    workExpService: Services.WorkExpService,
                    referenceService: Services.ReferenceService,
                    uploadService: Services.UploadService) {

                    $scope.InitCreateProfile = () => {
                        $scope.uploadImage = {};
                        $scope.uploadImage.myImage = '';
                        $scope.uploadImage.myCroppedImage = '';
                        $scope.uploadImage.change = false;

                        $scope.steps = [
                            'personalInformation',
                            'education',
                            'workExperience',
                            'skill',
                            'reference'
                        ];
                        $scope.step = $scope.steps[0];

                        $scope.ProfileId = null;
                        $scope.Profile = {};
                        $scope.Educations = [];
                        $scope.Skills = [];
                        $scope.References = [];
                        $scope.WorkExps = [];

                        var tokens = $location.$$absUrl.split("/");
                        var id = "";

                        var regexGuid = /^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$/gi;
                        for (let token of tokens) {
                            var isGuid = regexGuid.test(token);
                            if (isGuid) {
                                id = token;
                                break;
                            }
                        }

                        if (id != null && id.length > 0) {
                            //update
                            profileService.GetProfile(id)
                                .then((response) => {
                                    if (response.status == 200) {
                                        var res = <any>response.data;
                                        $scope.ProfileId = res.PersonalInformation.Id;
                                        $scope.ProfileGuidId = res.PersonalInformation.IdProfile;
                                        $scope.Profile = res.PersonalInformation;
                                        $scope.uploadImage.myImage = $scope.Profile.Photo;

                                        $scope.Educations = res.Educations;
                                        $scope.Skills = res.Skills;
                                        $scope.WorkExps = res.WorkExps;
                                        $scope.References = res.References;
                                    }
                                });
                        }
                    }

                    $scope.uploadFileNameChanged = (evt) => {
                        var file = evt.currentTarget.files[0];
                        var reader = new FileReader();
                        reader.onload = function (evt) {
                            $scope.$apply(function ($scope) {
                                $scope.uploadImage.myImage = (<any>evt.target).result;
                                $scope.uploadImage.change = true;
                            });
                        };
                        reader.readAsDataURL(file);
                    };

                    $scope.SubmitPersonalInfo = () => {
                        var profile = $scope.Profile;
                        profileService.SubmitPersonalInfo(profile)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    if ($scope.ProfileId == null) {
                                        $location.path($location.$$path + (<any>response.data).GuidId);
                                    }
                                    $scope.Profile.Id = (<any>response.data).Id;
                                    $scope.Profile.IdProfile = (<any>response.data).GuidId;
                                    $scope.ProfileId = (<any>response.data).Id;
                                    $scope.ProfileGuidId = (<any>response.data).GuidId;
                                }
                            });
                    };

                    $scope.SubmitPhoto = () => {
                        uploadService.CvPhoto($scope.uploadImage.myCroppedImage)
                            .then((response) => {
                                if (response.status == 200) {
                                    $scope.Profile.Photo = (<any>response.data).Photo;
                                    if ($scope.Profile.Id != null) {
                                        $scope.SubmitPersonalInfo();
                                    }
                                    else {
                                        logger.log("Your photo was uploaded successfully.");
                                    }
                                }
                            });
                    };

                    $scope.onCropPhoto = () => {
                        console.log("a");
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
                            case 'workExperience': {
                                $scope.SubmitWorkExps();
                                break;
                            }
                            case 'skill': {
                                $scope.SubmitSkills();
                                break;
                            }
                            case 'reference': {
                                $scope.SubmitRefs();
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
                            case 'workExperience': {
                                $scope.GotoWorkExp();
                                break;
                            }
                            case 'skill': {
                                $scope.GotoSkill();
                                break;
                            }
                            case 'reference': {
                                $scope.GotoRef();
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
                        profileService.SubmitEdus($scope.ProfileId, $scope.Educations)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.RebindEdus();
                                }
                            });
                    };

                    $scope.RebindEdus = () => {
                        $scope.Educations = [];
                        profileService.GetEdus($scope.ProfileId)
                            .then((response) => {
                                if (response.status == 200) {
                                    $scope.Educations = response.data;
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
                        skillService.SubmitSkills($scope.ProfileId, $scope.Skills)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.RebindSkills();
                                }
                            });
                    };

                    $scope.RebindSkills = () => {
                        $scope.Skills = [];
                        skillService.GetSkills($scope.ProfileId)
                            .then((response) => {
                                if (response.status == 200) {
                                    $scope.Skills = response.data;
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

                    $scope.SubmitWorkExps = () => {
                        workExpService.SubmitWorkExps($scope.ProfileId, $scope.WorkExps)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.RebindWorkExps();
                                }
                            });
                    };

                    $scope.RebindWorkExps = () => {
                        $scope.WorkExps = [];
                        workExpService.GetWorkExps($scope.ProfileId)
                            .then((response) => {
                                if (response.status == 200) {
                                    $scope.WorkExps = response.data;
                                }
                            });
                    };

                    //reference
                    $scope.RemoveRef = (index) => {
                        $scope.References.splice(index, 1);
                    };

                    $scope.AddRef = () => {
                        $scope.References.push({
                            IdProfile: $scope.ProfileId
                        });
                    };

                    $scope.SubmitRefs = () => {
                        referenceService.SubmitRefs($scope.ProfileId, $scope.References)
                            .then((response) => {
                                if (response.status == 200) {
                                    logger.log("Saved successfully.");
                                    $scope.RebindRefs();
                                }
                            });
                    };

                    $scope.RebindRefs = () => {
                        $scope.References = [];
                        referenceService.GetRefs($scope.ProfileId)
                            .then((response) => {
                                if (response.status == 200) {
                                    $scope.References = response.data;
                                }
                            });
                    };
                });
        }
    }
}