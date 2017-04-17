/// <reference path="../references.ts" />

module CVGen.Services {
    export class TemplateService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }
              
        GetAll = () => {         
            return this.httpService({
                method: 'GET',
                url: "/api/Temp/GetAll",
            });
        }
    }
}