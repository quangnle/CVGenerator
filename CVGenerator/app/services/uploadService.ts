/// <reference path="../references.ts" />

module CVGen.Services {
    export class UploadService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

     
        CvPhoto = (imageString64) => {
            var model = { Content: imageString64 };
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/upload/CvPhoto",
            });
        }      
    }
}