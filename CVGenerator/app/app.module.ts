/// <reference path="references.ts" />
'use strict';
((): void => {
    var cvGeneratorApp = angular.module("cvGeneratorApp", []);

    CVGen.Controller.Home.Configure(cvGeneratorApp);
    CVGen.Controller.Resume.Configure(cvGeneratorApp);
    CVGen.Controller.Profile.Configure(cvGeneratorApp);
})()