/// <reference path="../references.ts" />

module CVGen.Services {
    export class SkillService {
        httpService: ng.IHttpService
        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {
            this.httpService = $http;
        }

        SubmitSkills = (model) => {
            return this.httpService({
                data: model,
                method: 'POST',
                url: "/api/Skill/SubmitSkills",
            });
        }
    }
}