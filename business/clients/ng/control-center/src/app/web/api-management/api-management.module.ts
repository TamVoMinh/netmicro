import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiManagementRoutingModule } from './api-management-routing.module';
import { ApiListComponent } from './components/api-list/api-list.component';
import { SharedModule } from '@shared/shared.module';


@NgModule({
  declarations: [ApiListComponent],
  imports: [
    CommonModule,
    SharedModule,
    ApiManagementRoutingModule
  ]
})
export class ApiManagementModule { }
