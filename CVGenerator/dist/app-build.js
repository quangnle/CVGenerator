/// <reference path="../references.ts" />
'use strict';
var CVGen;
(function (CVGen) {
    var Controller;
    (function (Controller) {
        var Home = (function () {
            function Home() {
            }
            //public static $inject = ['$scope', '$filter', '$location'];
            Home.Configure = function (module) {
                module.controller('HomeCtrl', function () {
                });
            };
            return Home;
        }());
        Controller.Home = Home;
    })(Controller = CVGen.Controller || (CVGen.Controller = {}));
})(CVGen || (CVGen = {}));
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
                module.controller('ResumeCtrl', function ($scope, profileService) {
                    $scope.SubmitResume = function () {
                    };
                });
            };
            return Resume;
        }());
        Resume.$inject = ['$scope', 'profileService'];
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
                module.controller('ProfileCtrl', function ($scope, logger, profileService) {
                    $scope.SubmitProfile = function () {
                        // doing submit
                        profileService.Test()
                            .then(function (response) {
                            if (response.status == 200) {
                                alert(response.data);
                            }
                        });
                        //alert('submitted');
                    };
                    $scope.GotoWorkExp = function () {
                        logger.log("asdads");
                        // doing submit
                        //  alert('submitted');
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
        Profile.$inject = ['$scope', 'logger', 'profileService'];
        Controller.Profile = Profile;
    })(Controller = CVGen.Controller || (CVGen.Controller = {}));
})(CVGen || (CVGen = {}));
/// <reference path="../references.ts" />
var CVGen;
/// <reference path="../references.ts" />
(function (CVGen) {
    var Services;
    (function (Services) {
        var ProfileService = (function () {
            function ProfileService($http) {
                var _this = this;
                this.Test = function () {
                    return _this.httpService({
                        method: 'GET',
                        url: "/api/Profile/Test",
                    });
                };
                this.httpService = $http;
            }
            return ProfileService;
        }());
        ProfileService.$inject = ["$http"];
        Services.ProfileService = ProfileService;
    })(Services = CVGen.Services || (CVGen.Services = {}));
})(CVGen || (CVGen = {}));
/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../Scripts/typings/toastr/toastr.d.ts" />
/// <reference path="controllers/app.module.home.ts" />
/// <reference path="controllers/app.module.resume.ts" />
/// <reference path="controllers/app.module.profile.ts" />
/// <reference path="services/profileService.ts" /> 
/// <reference path="references.ts" />
'use strict';
(function () {
    var cvGeneratorApp = angular.module("cvGeneratorApp", []);
    cvGeneratorApp.factory('httpInterceptor', ['logger', function (_) { return httpInterceptor(_); }]);
    cvGeneratorApp.config(['$httpProvider', function ($httpProvider) {
            $httpProvider.interceptors.push('httpInterceptor');
        }]);
    function httpInterceptor(logger) {
        return {
            response: function (res) {
                if (res.status != 200) {
                    logger.logWarning("ERROR CODE " + res.status);
                }
                return res;
            },
            responseError: function (res) {
                switch (res.status) {
                    default:
                        debugger;
                        logger.logError("# RESPONSE ERROR STATUS CODE " + res.status);
                        break;
                }
                return res;
            }
        };
    }
    cvGeneratorApp.service("profileService", CVGen.Services.ProfileService);
    CVGen.Controller.Home.Configure(cvGeneratorApp);
    CVGen.Controller.Resume.Configure(cvGeneratorApp);
    CVGen.Controller.Profile.Configure(cvGeneratorApp);
    cvGeneratorApp.factory("logger", [
        function () {
            var logIt;
            return toastr.options = {
                closeButton: !0,
                positionClass: "toast-bottom-right",
                timeOut: 3000
            }, logIt = function (message, type) {
                return toastr[type](message);
            }, {
                log: function (message) {
                    logIt(message, "info");
                },
                logWarning: function (message) {
                    logIt(message, "warning");
                },
                logSuccess: function (message) {
                    logIt(message, "success");
                },
                logError: function (message) {
                    logIt(message, "error");
                }
            };
        }
    ]);
})();
//# sourceMappingURL=app-build.js.map