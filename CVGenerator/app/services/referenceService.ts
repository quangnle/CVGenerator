/// <reference path="../references.ts" />

module CVGen.Services {
    export class ReferenceService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        SubmitRefs = (profileId, model) => {
            var params = { profileId: profileId };
            return this.httpService({
                params: params,
                data: model,
                method: 'POST',
                url: "/api/ref/SubmitRefs",
            });
        }

        GetRefs = (idProfile) => {
            var params = { idProfile: idProfile };
            return this.httpService({
                params: params,
                method: 'GET',
                url: "/api/ref/GetRefs",
            });
        }        
    }
}