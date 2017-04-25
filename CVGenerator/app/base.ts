module CVGen.Base {
    declare var userToken: any;
    export var UserToken = userToken;

    export class Const {
        static get USER_TOKEN(): string {
            return Base.UserToken;
        }
        static set USER_TOKEN(token: string) {
            Base.UserToken = token;
        }
    }
}