/// <reference path="references.ts" />
'use strict';
((): void => {
    var cvGeneratorApp = angular.module("cvGeneratorApp", []);

    cvGeneratorApp.factory('httpInterceptor', ['logger', _ => httpInterceptor(_)]);
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
        }
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
                }
        }
    ]);
})()