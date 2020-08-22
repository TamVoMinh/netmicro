import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JWTInterceptor } from './common/_helper';
import { environment } from '@environments/environment';
import { NbIconModule, NbActionsModule, NbButtonModule, NbCardModule, NbSearchModule, NbSelectModule, NbUserModule, NbListModule, NbTreeGridModule, NbInputModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { LoadingIndicatorModule } from '@shared/common/_component/loading-indicator/loading-indicator.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NbIconModule,
    NbEvaIconsModule,
    NbActionsModule,
    NbButtonModule,
    NbCardModule,
    NbSearchModule,
    NbSelectModule,
    NbUserModule,
    NbListModule,
    LoadingIndicatorModule,
    NbTreeGridModule,
    NbInputModule,
    PaginationModule.forRoot()
  ],
  exports: [
    LoadingIndicatorModule,
    FormsModule,
    ReactiveFormsModule,
    NbIconModule,
    NbEvaIconsModule,
    NbActionsModule,
    NbButtonModule,
    NbCardModule,
    NbSearchModule,
    NbSelectModule,
    NbUserModule,
    NbListModule,
    NbTreeGridModule,
    NbInputModule,
    PaginationModule
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
      provide: 'API_URL',
      useFactory: getApiUrl
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

export function getApiUrl() {
    return `${environment.apiUrl}`;
}
