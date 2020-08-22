import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientManagementRoutingModule } from './client-management-routing.module';
import { SharedModule } from '@shared/shared.module';
import { ClientsComponent as ClientsContainerComponent } from './containers/clients/clients.component';
import { ClientsComponent } from './components/clients/clients.component';


@NgModule({
  declarations: [ClientsComponent, ClientsContainerComponent],
  imports: [
    CommonModule,
    SharedModule,
    ClientManagementRoutingModule
  ]
})
export class ClientManagementModule { }
