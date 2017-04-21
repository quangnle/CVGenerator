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

        GetProfile = (idProfile) => {
            var params = { idProfile: idProfile };
            return this.httpService({
                params: params,
                method: 'GET',
                url: "/api/Profile/GetUserProfile",
            });
        }

        SubmitPersonalInfo = (model) => {
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/Profile/SubmitPersonalInfo",
            });
        }



        SubmitEdus = (profileId, model) => {
            var params = { profileId: profileId };
            return this.httpService({
                params: params,
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