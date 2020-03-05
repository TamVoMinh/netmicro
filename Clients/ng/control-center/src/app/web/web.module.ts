import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebRoutingModule } from './web-routing.module';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
  declarations: [
    HomeComponent, 
    DashboardComponent, 
    UnauthorizedComponent
  ],
  imports: [
    CommonModule,
    WebRoutingModule,
    SharedModule
  ],
  exports: [
    HomeComponent, 
    DashboardComponent
  ]
})
export class WebModule { }
