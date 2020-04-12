import { Log, User, UserManager, SessionStatus } from 'oidc-client';

import { Constants } from '../helpers/Constants';

export class AuthService {
    public userManager: UserManager;
    public redirect_uri = `${Constants.clientRoot}/apps/dashboard/signin-callback.html`;
    public silent_redirect_uri = `${Constants.clientRoot}/apps/dashboard/silent-renew.html`;
    constructor() {
        const settings = {
            authority: Constants.stsAuthority,
            client_id: Constants.clientId,

            // tslint:disable-next-line:object-literal-sort-keys

            silent_redirect_uri: this.silent_redirect_uri,
            redirect_uri: this.redirect_uri,
            signout_callback_oidc: `${Constants.clientRoot}`,
            post_logout_redirect_uri: `${Constants.clientRoot}`,
            response_type: 'id_token token',
            scope: Constants.clientScope
            // revokeAccessTokenOnSignout: true
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
    public loginSilent(): Promise<User | undefined> {
        return this.userManager.signinSilent();
    }

    public renewToken(): Promise<User> {
        return this.userManager.signinSilent();
    }

    public logout(): Promise<void> {
        return this.userManager.signoutRedirect();
    }

    public querySessionStatus(args?: any): Promise<SessionStatus> {
        return this.userManager.querySessionStatus(args);
    }
}
