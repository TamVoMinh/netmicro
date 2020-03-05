import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatMenuModule, MatToolbarModule, MatSidenavModule, MatListModule, MatCardModule } from '@angular/material';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {MatIconModule} from '@angular/material/icon'; 
import { JWTInterceptor } from './common/_helper';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatCardModule,
  ],
  exports: [
    HttpClientModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatCardModule,
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
  return `${window.location.protocol}//${window.location.hostname}${!!window.location.port? ":" + window.location.port : ""}`;
}
export function getAuthUrl() {
  return `${environment.oidc.stsServer}`;
}