import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '@shared/common/_service/base/base.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, delay } from 'rxjs/operators';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { IUser } from '../../_model';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {
  constructor(
    public oidcSecurityService: OidcSecurityService,
    public http: HttpClient,
    @Inject('BASE_URL') private originUrl: string,
  ) {
    super(http, oidcSecurityService);
   }

   getUsersList(): Observable<any> {
     return this.http.get('http://localhost:4200/assets/mock-data' + `/users.json`).pipe(delay(5000));
   }

}
