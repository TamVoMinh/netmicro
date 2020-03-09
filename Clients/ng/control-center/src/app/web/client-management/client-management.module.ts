import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientManagementRoutingModule } from './client-management-routing.module';
import { ClientListComponent } from './components/client-list/client-list.component';
import { SharedModule } from '@shared/shared.module';


@NgModule({
  declarations: [ClientListComponent],
  imports: [
    CommonModule,
    SharedModule,
    ClientManagementRoutingModule
  ]
})
export class ClientManagementModule { }
