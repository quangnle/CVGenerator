/// <reference path="../references.ts" />

module CVGen.Services {
    export class ProfileService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        Test = () => {           
            return this.httpService({
                method: 'GET',
                url:  "/api/Profile/Test",
            });
        }

    }
}