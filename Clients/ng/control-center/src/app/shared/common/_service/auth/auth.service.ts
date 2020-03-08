import { Injectable, Inject, OnDestroy } from '@angular/core';
import {
  OidcSecurityService,
  OpenIdConfiguration,
  AuthWellKnownEndpoints,
  AuthorizationResult,
  AuthorizationState,
} from 'angular-auth-oidc-client';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { BaseService } from '@shared/common/_service/base/base.service';
import { environment } from '@environments/environment';

declare const window: Window;
@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService implements OnDestroy {

  isAuthorized = false;
  constructor(
    public oidcSecurityService: OidcSecurityService,
    public http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private originUrl: string,
    @Inject('AUTH_URL') private authUrl: string
  ) {
    super(http, oidcSecurityService);
  }

  private isAuthorizedSubscription: Subscription = new Subscription();

  ngOnDestroy(): void {
    if (this.isAuthorizedSubscription) {
      this.isAuthorizedSubscription.unsubscribe();
    }
  }

  public initAuth() {
    const openIdConfiguration: OpenIdConfiguration = {
      stsServer: this.authUrl,
      redirect_url: this.originUrl,
      client_id: environment.oidc.client_id,
      response_type: 'code',
      scope: 'openid profile email',
      post_logout_redirect_uri: this.originUrl,
      forbidden_route: '/login',
      unauthorized_route: '/login',
      silent_renew: true,
      silent_renew_url: this.originUrl + '/silent-renew.html',
      history_cleanup_off: true,
      auto_userinfo: true,
      log_console_warning_active: true,
      log_console_debug_active: true,
      max_id_token_iat_offset_allowed_in_seconds: 10,
    };

    const authWellKnownEndpoints: AuthWellKnownEndpoints = {
      issuer: this.authUrl,
      jwks_uri: this.authUrl + '/.well-known/openid-configuration/jwks',
      authorization_endpoint: this.authUrl + '/connect/authorize',
      token_endpoint: this.authUrl + '/connect/token',
      userinfo_endpoint: this.authUrl + '/connect/userinfo',
      end_session_endpoint: this.authUrl + '/connect/endsession',
      check_session_iframe: this.authUrl + '/connect/checksession',
      revocation_endpoint: this.authUrl + '/connect/revocation',
      introspection_endpoint: this.authUrl + '/connect/introspect',
    };

    this.oidcSecurityService.setupModule(openIdConfiguration, authWellKnownEndpoints);

    if (this.oidcSecurityService.moduleSetup) {
      this.doCallBackLogicIfRequired();
    } else {
      this.oidcSecurityService.onModuleSetup.subscribe(() => {
        this.doCallBackLogicIfRequired();
      });
    }

    this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe((isAuthorized => {
      this.isAuthorized = isAuthorized;
    }));

    this.oidcSecurityService.onAuthorizationResult.subscribe(
      (authorizationResult: AuthorizationResult) => {
        this.onAuthorizationResultComplete(authorizationResult);
      });
  }

  private onAuthorizationResultComplete(authorizationResult: AuthorizationResult) {
    console.log('Auth result received AuthorizationState:'
      + authorizationResult.authorizationState
      + ' validationResult:' + authorizationResult.validationResult);

    if (authorizationResult.authorizationState === AuthorizationState.unauthorized) {
      if (window.parent) {
        this.router.navigate(['/login']);
      } else {
        window.location.href = '/web';
      }
    }
  }

  private doCallBackLogicIfRequired() {
    this.oidcSecurityService.authorizedCallbackWithCode(window.location.toString());
  }

  getIsAuthorized(): Observable<boolean> {
    return this.oidcSecurityService.getIsAuthorized();
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }
}
