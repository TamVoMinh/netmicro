import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AuthModule, ConfigResult, OidcConfigService, OidcSecurityService, OpenIdConfiguration } from 'angular-auth-oidc-client';

// const oidc_configuration = './assets/auth.clientConfiguration.json';

// export function loadConfig(oidcConfigService: OidcConfigService) {
//   return () => oidcConfigService.load(oidc_configuration);
// }
export function loadConfig(oidcConfigService: OidcConfigService) {
  return () => oidcConfigService.load_using_stsServer('http://oidc.nmro.local');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule.forRoot()
  ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: loadConfig,
      deps: [OidcConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(
    private oidcSecurityService: OidcSecurityService,
    private oidcConfigService: OidcConfigService
  ) {
    this.oidcConfigService.onConfigurationLoaded.subscribe((configResult: ConfigResult) => {
      const config: OpenIdConfiguration = {
        stsServer: configResult.customConfig.stsServer,
        redirect_url: 'http://engage.nmro.local/signin-callback.html',
        client_id: 'nmro-angular-client',
        scope: 'openid profile email',
        response_type: 'code',
        silent_renew: true,
        silent_renew_url: 'https://localhost:4200/silent-renew.html',
        log_console_debug_active: true,
      };
      this.oidcSecurityService.setupModule(config, configResult.authWellknownEndpoints);
    });
  }
}
