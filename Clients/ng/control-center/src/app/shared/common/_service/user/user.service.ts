import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '@shared/common/_service/base/base.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {
  private userSubject = new BehaviorSubject<any>(null);
  userData$: Observable<any>;
  constructor(
    public oidcSecurityService: OidcSecurityService,
    public http: HttpClient,
  ) {
    super(http, oidcSecurityService);
    this.userData$ = this.userSubject.asObservable();
   }

   getUserData() : Observable<any> {
    return this.oidcSecurityService.getUserData().pipe(
      map(user => {
        this.userSubject.next(user)
      })
    );
   }

}
