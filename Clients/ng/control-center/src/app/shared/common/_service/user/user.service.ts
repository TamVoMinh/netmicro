import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '@shared/common/_service/base/base.service';
import { Observable } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { IUser, IHttpResponse } from '../../_model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {
  constructor(
    public oidcSecurityService: OidcSecurityService,
    public http: HttpClient,
    @Inject('API_URL') private apiUrl: string,
  ) {
    super(http, oidcSecurityService);
  }

  getUsersList(params): Observable<IHttpResponse<IUser[]>> {
    return this.http.get<IHttpResponse<IUser[]>>(this.apiUrl + `/Users`, { params: params });
  }
}
