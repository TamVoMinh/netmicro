import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor(protected http: HttpClient, protected oidcSecurityService: OidcSecurityService) { }

  get(url: string): Observable<any> {
    return this.http.get(url, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.oidcSecurityService.handleError(error);
        return throwError(error);
      }));
  }

  put(url: string, data: any): Observable<any> {
    const body = JSON.stringify(data);
    return this.http.put(url, body, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.oidcSecurityService.handleError(error);
        return throwError(error);
      }));
  }

  delete(url: string): Observable<any> {
    return this.http.delete(url, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.oidcSecurityService.handleError(error);
        return throwError(error);
      }));
  }

  post(url: string, data: any): Observable<any> {
    const body = JSON.stringify(data);
    return this.http.post(url, body, { headers: this.getHeaders() })
      .pipe(catchError((error) => {
        this.oidcSecurityService.handleError(error);
        return throwError(error);
      }));
  }

  private getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    return this.appendAuthHeader(headers);
  }

  public getToken() {
    const token = this.oidcSecurityService.getToken();
    return token;
  }

  private appendAuthHeader(headers: HttpHeaders) {
    const token = this.oidcSecurityService.getToken();

    if (token === '') { return headers; }

    const tokenValue = 'Bearer ' + token;
    return headers.set('Authorization', tokenValue);
  }
}
