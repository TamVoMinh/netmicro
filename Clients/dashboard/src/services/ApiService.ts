import axios from 'axios';
import { Constants } from '../helpers/Constants';
import { AuthService } from './AuthService';
import { User } from 'oidc-client';

export class ApiService {
    private authService: AuthService;
    private authorization: string | undefined;
    constructor() {
        this.authService = new AuthService();
        this.authService.getUser().then((user: User | null) => {
            if (user) {
                this.authorization = user?.access_token;
            }
        });
    }

    public get(url: string) {
        const headers = {
            Accept: 'application/json',
            Authorization: this.authorization
        };
        return axios.get(Constants.apiRoot + url, { headers });
    }

    public post(url: string) {
        const headers = {
            Accept: 'application/json',
            Authorization: this.authorization
        };
        return axios.post(Constants.apiRoot + url, { headers });
    }
}
