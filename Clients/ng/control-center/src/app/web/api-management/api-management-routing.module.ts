import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApiListComponent } from './components/api-list/api-list.component';


const routes: Routes = [
  { path: '', component: ApiListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApiManagementRoutingModule { }
