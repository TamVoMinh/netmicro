import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { ToolbarComponent } from './layout/toolbar/toolbar.component';
import { LoginComponent } from './login/login.component';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import {
  AuthModule,
  OidcConfigService,
} from "angular-auth-oidc-client";
import { environment } from 'src/environments/environment';

export function loadOidcConfiguration(oidcConfigService: OidcConfigService) {
  return () =>
    oidcConfigService.load_using_custom_stsServer(
      `${environment.oidc.stsServer}/.well-known/openid-configuration`
    );
}

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    SidenavComponent,
    ToolbarComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
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
  ]
})
export class CoreModule { }
