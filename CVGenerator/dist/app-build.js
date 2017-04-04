/// <reference path="../references.ts" />
'use strict';
var CVGen;
(function (CVGen) {
    var Controller;
    (function (Controller) {
        var Resume = (function () {
            function Resume() {
            }
            Resume.Configure = function (module) {
                module.controller('ResumeCtrl', function ($scope) {
                    $scope.SubmitResume = function () {
                        alert("ád");
                    };
                });
            };
            return Resume;
        }());
        Resume.$inject = ['$scope'];
        Controller.Resume = Resume;
    })(Controller = CVGen.Controller || (CVGen.Controller = {}));
})(CVGen || (CVGen = {}));
/// <reference path="../references.ts" />
'use strict';
var CVGen;
(function (CVGen) {
    var Controller;
    (function (Controller) {
        var Profile = (function () {
            function Profile() {
            }
            Profile.Configure = function (module) {
                module.controller('ProfileCtrl', function ($scope) {
                    $scope.SubmitProfile = function () {
                        alert('submitted');
                    };
                    $scope.GotoWorkExp = function () {
                        alert('submitted');
                    };
                    $scope.GotoEducation = function () {
                        // doing submit
                        alert('GotoEducation');
                    };
                    $scope.GotoSkill = function () {
                        // doing submit
                        alert('GotoSkill');
                    };
                    $scope.GotoRef = function () {
                        // doing submit
                        alert('GotoRef');
                    };
                });
            };
            return Profile;
        }());
        Profile.$inject = ['$scope'];
        Controller.Profile = Profile;
    })(Controller = CVGen.Controller || (CVGen.Controller = {}));
})(CVGen || (CVGen = {}));
/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="controllers/app.module.home.ts" />
/// <reference path="controllers/app.module.resume.ts" />
/// <reference path="controllers/app.module.profile.ts" /> 
/// <reference path="../references.ts" />
'use strict';
var CVGen;
(function (CVGen) {
    var Controller;
    (function (Controller) {
        var Home = (function () {
            function Home() {
            }
            Home.Configure = function (module) {
                //public static $inject = ['$scope', '$filter', '$location'];
                module.controller('HomeCtrl', function () {
                });
            };
            return Home;
        }());
        Controller.Home = Home;
    })(Controller = CVGen.Controller || (CVGen.Controller = {}));
})(CVGen || (CVGen = {}));
/// <reference path="references.ts" />
'use strict';
(function () {
    var cvGeneratorApp = angular.module("cvGeneratorApp", []);
    CVGen.Controller.Home.Configure(cvGeneratorApp);
    CVGen.Controller.Resume.Configure(cvGeneratorApp);
    CVGen.Controller.Profile.Configure(cvGeneratorApp);
})();
//# sourceMappingURL=app-build.js.map