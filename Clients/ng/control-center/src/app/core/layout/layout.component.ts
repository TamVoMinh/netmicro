import { Component, OnInit, ViewChild } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { SidenavComponent } from './sidenav/sidenav.component';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isAuthorized$: Observable<any>;
  @ViewChild('sidebar', { static: true }) sidebar: SidenavComponent;

  constructor(
    public authService: AuthService
  ) {}

  ngOnInit() {
    this.isAuthorized$ = this.authService.getIsAuthorized();
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

  toggleSideBar() {
    this.sidebar.toggleSideNav();
  }
}
