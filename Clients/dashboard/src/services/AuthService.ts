import { Log, User, UserManager } from 'oidc-client';

import { Constants } from '../helpers/Constants';

export class AuthService {
    public userManager: UserManager;

    constructor() {
        const settings = {
            authority: Constants.stsAuthority,
            client_id: Constants.clientId,

            // tslint:disable-next-line:object-literal-sort-keys

            silent_redirect_uri: `${Constants.clientRoot}/silent-renew.html`,
            redirect_uri: `${Constants.clientRoot}/apps/dashboard/signin-callback.html`,
            signout_callback_oidc: `${Constants.clientRoot}`,
            post_logout_redirect_uri: `${Constants.clientRoot}`,
            response_type: 'id_token token',
            scope: Constants.clientScope
        };
        this.userManager = new UserManager(settings);

        Log.logger = console;
        Log.level = Log.INFO;
    }

    public getUser(): Promise<User | null> {
        return this.userManager.getUser();
    }

    public login(): Promise<void> {
        return this.userManager.signinRedirect();
    }

    public renewToken(): Promise<User> {
        return this.userManager.signinSilent();
    }

    public logout(): Promise<void> {
        return this.userManager.signoutRedirect();
    }
}
