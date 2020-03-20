import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
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
import { StoreModule } from '@ngrx/store';
import { appReducers } from './store/reducers/app.reducers';
import { EffectsModule } from '@ngrx/effects';
import { UserEffect } from './store/effects/user.effect';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { LoadingEffect } from './store/effects/loading.effects';

export const effects = [
  UserEffect,
  LoadingEffect
]

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
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
    StoreModule.forRoot(appReducers),
    EffectsModule.forRoot(effects),
    StoreRouterConnectingModule.forRoot({ stateKey: 'router' }),
    environment.production ? [] : StoreDevtoolsModule.instrument()
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
