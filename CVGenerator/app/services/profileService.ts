/// <reference path="../references.ts" />

module CVGen.Services {
    export class ProfileService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        SubmitProfile = (profileModel) => {
            return this.httpService({
                data: profileModel,
                method: 'POST',
                url: "/api/Profile/SubmitProfile",
            });
        }

        SubmitPersonalInfo = (model) => {
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/Profile/SubmitPersonalInfo",
            });
        }

        SubmitSkills = (model) => {
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/Skill/SubmitSkills",
            });
        }

        SubmitEdus = (model) => {
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/Edu/SubmitEdus",
            });
        }

        GetEdus = (idProfile) => {
            var params = { idProfile: idProfile };
            return this.httpService({
                params: params,
                method: 'GET',
                url: "/api/Edu/GetEdus",
            });
        }

    }
}