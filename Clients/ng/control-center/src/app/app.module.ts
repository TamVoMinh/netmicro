import { BrowserModule } from "@angular/platform-browser";
import { NgModule, APP_INITIALIZER } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HttpClientModule } from "@angular/common/http";
import {
  AuthModule,
  ConfigResult,
  OidcSecurityService,
  OidcConfigService,
  OpenIdConfiguration
} from "angular-auth-oidc-client";
import { environment } from "../environments/environment";

export function loadOidcConfiguration(oidcConfigService: OidcConfigService) {
  return () =>
    oidcConfigService.load_using_custom_stsServer(
      `${environment.oidc.stsServer}/.well-known/openid-configuration`
    );
}
declare const window: Window;
@NgModule({
  declarations: [AppComponent],
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
      useFactory: loadOidcConfiguration,
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
    this.oidcConfigService.onConfigurationLoaded.subscribe(
      (configResult: ConfigResult) => {
        // Use the configResult to set the configurations
        const hostOrigin = `${window.location.protocol}//${window.location.hostname}${!!window.location.port? ":" + window.location.port : ""}`
        const config: OpenIdConfiguration = {
          stsServer: configResult.customConfig.stsServer,
          redirect_url: `${hostOrigin}`,
          client_id: environment.oidc.client_id,
          scope: "openid profile email",
          response_type: "id_token token",
          silent_renew: true,
          silent_renew_url: `${hostOrigin}/silent-renew.html`,
          log_console_debug_active: true
        };

        this.oidcSecurityService.setupModule(
          config,
          configResult.authWellknownEndpoints
        );
      }
    );
  }
}
