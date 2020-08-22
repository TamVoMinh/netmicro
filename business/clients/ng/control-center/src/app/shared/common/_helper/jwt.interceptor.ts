import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable()
export class JWTInterceptor implements HttpInterceptor {
    constructor(private oidcSecurityService: OidcSecurityService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let requestToForward = request;
        let token = this.oidcSecurityService.getToken();
        if(token) {
            let tokenValue = 'Bearer ' +  token;
            requestToForward = request.clone({setHeaders: { Authorization: tokenValue }});
        }
        return next.handle(requestToForward);
    }

}
