import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { BaseService } from '..';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService extends BaseService {

  constructor(
    public oidcSecurityService: OidcSecurityService,
    public http: HttpClient,
    @Inject('API_URL') private apiUrl: string,
  ) {
    super(http, oidcSecurityService);
  }

  getClientList(params): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/clients', { params: params });
  }
}
