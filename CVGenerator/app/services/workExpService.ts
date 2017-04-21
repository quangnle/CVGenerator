/// <reference path="../references.ts" />

module CVGen.Services {
    export class WorkExpService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        SubmitWorkExps = (profileId, model) => {
            var params = { profileId: profileId };
            return this.httpService({
                params: params,
                data: model,
                method: 'POST',
                url: "/api/WorkExp/SubmitWorkExps",
            });
        }

        GetWorkExps = (idProfile) => {
            var params = { idProfile: idProfile };
            return this.httpService({
                params: params,
                method: 'GET',
                url: "/api/WorkExp/GetWorkExps",
            });
        }
    }
}