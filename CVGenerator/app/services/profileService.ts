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
                url:  "/api/Profile/SubmitProfile",
            });
        }

    }
}