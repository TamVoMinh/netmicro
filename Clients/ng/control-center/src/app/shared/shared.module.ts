import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JWTInterceptor } from './common/_helper';
import { environment } from '@environments/environment';
import { NbIconModule, NbActionsModule, NbButtonModule, NbCardModule, NbSearchModule, NbSelectModule, NbUserModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NbIconModule,
    NbEvaIconsModule,
    NbActionsModule,
    NbButtonModule,
    NbCardModule,
    NbSearchModule,
    NbSelectModule,
    NbUserModule,
  ],
  exports: [
    NbIconModule,
    NbEvaIconsModule,
    NbActionsModule,
    NbButtonModule,
    NbCardModule,
    NbSearchModule,
    NbSelectModule,
    NbUserModule
  ],
  providers: [
    {
      provide: 'BASE_URL',
      useFactory: getBaseUrl
    },
    {
      provide: 'AUTH_URL',
      useFactory: getAuthUrl
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JWTInterceptor,
      multi: true
    }
  ]
})
export class SharedModule { }
export function getBaseUrl() {
  return `${window.location.protocol}//${window.location.hostname}${!!window.location.port ? ':' + window.location.port : ''}`;
}
export function getAuthUrl() {
  return `${environment.oidc.stsServer}`;
}