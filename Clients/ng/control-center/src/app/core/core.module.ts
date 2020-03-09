import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { ToolbarComponent } from './layout/toolbar/toolbar.component';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

import { environment } from 'src/environments/environment';
import {
  NbThemeModule,
  NbSidebarModule,
  NbMenuModule,
  NbLayoutModule
} from '@nebular/theme';
import {
  AuthModule,
  OidcConfigService,
} from 'angular-auth-oidc-client';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    SidenavComponent,
    ToolbarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    NbLayoutModule,
    AuthModule.forRoot(),
    NbThemeModule,
    NbSidebarModule,
    NbMenuModule,
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

export function loadOidcConfiguration(oidcConfigService: OidcConfigService) {
  return () =>
    oidcConfigService.load_using_custom_stsServer(
      `${environment.oidc.stsServer}/.well-known/openid-configuration`
    );
}