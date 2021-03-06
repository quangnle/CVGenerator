﻿/// <reference path="../references.ts" />

module CVGen.Services {
    export class SkillService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        SubmitSkills = (profileId, model) => {
            var params = { profileId: profileId };
            return this.httpService({
                data: model,
                params: params,
                method: 'POST',
                url: "/api/Skill/SubmitSkills",
            });
        }

        GetSkills = (idProfile) => {
            var params = { idProfile: idProfile };
            return this.httpService({
                params: params,
                method: 'GET',
                url: "/api/skill/GetSkills",
            });
        }
    }
}