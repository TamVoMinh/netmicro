import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { SharedModule } from '@shared/shared.module';
import { UsersComponent as UsersContainerComponent } from './containers/users/users.component';
import { UsersComponent } from './components/users/users.component';

@NgModule({
  declarations: [
    UsersContainerComponent,
    UsersComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    UserManagementRoutingModule
  ]
})
export class UserManagementModule { }
