/// <reference path="../references.ts" />
'use strict';

module CVGen.Controller {
    declare var pdfMake: any;
    declare var html2canvas: any;
    export class UserResume {
        public static $inject = ['$scope', 'templateService'];
        public static MonthArray = ['January',
            'February',
            'March',
            'April',
            'May',
            'June',
            'July',
            'August',
            'September',
            'October',
            'November',
            'December'];

        static Configure(module: angular.IModule) {
            module.controller('UserResumeCtrl', function ($scope, templateService: Services.TemplateService) {

                $scope.InitViewUserProfile = (data) => {
                    $scope.TemplateSrc = data.Template.TemplateSrc;
                    $scope.TemplateSrcIndex = data.Template.TemplateSrc + 'index.html';
                    $scope.PersonalInformation = data.PersonalInformation;
                    $scope.Educations = data.Educations;
                    $scope.WorkExps = data.WorkExps;

                    for (var i = 0; i < $scope.WorkExps.length; i++) {
                        var work = $scope.WorkExps[i];
                        work.DescLines = work.Description.split(/\r?\n/);
                    }

                    $scope.Skills = data.Skills;
                    $scope.References = data.References;

                    $scope.Title = data.PersonalInformation.FirstName + " " + data.PersonalInformation.LastName + " - Curriculum Vitae";
                }

                $scope.InitViewMyCvs = (data) => {
                    $scope.AccountInfo = {};
                    $scope.AccountInfo.UserEmail = data.UserEmail;
                    $scope.PersonalInformations = data.PersonalInformations;
                }

                $scope.ExportMyCv = () => {
                    html2canvas(document.body, {
                        onrendered: function (canvas) {
                            var data = canvas.toDataURL();
                            var docDefinition = {
                                content: [{
                                    image: data,
                                    width: 500,
                                }]
                            };
                            pdfMake.createPdf(docDefinition).download($scope.Title + ".pdf");
                        }
                    });
                }

                $scope.GetRangeTime = (fromM, fromY, toM, toY) => {
                    var result = UserResume.MonthArray[fromM - 1];
                    result = result.concat(" ", fromY, " - ")
                    if (toM == null || toY == null) {
                        result = result.concat("present")
                    } else {
                        result = result.concat(UserResume.MonthArray[toM - 1], " ", toY)
                    }
                    return result;
                }
            })
        }
    }
}