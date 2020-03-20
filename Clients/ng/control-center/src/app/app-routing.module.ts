import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';
import { LoginComponent } from './web/login/login.component';
import { AuthGuard } from '@shared/common/_helper/auth.guard';
const routes: Routes = [
  {
    path: 'web',
    component: LayoutComponent,
    // canActivate: [AuthGuard],
    loadChildren: () => import('./web/web.module').then(m => m.WebModule)
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: 'web',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'web'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: false})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
