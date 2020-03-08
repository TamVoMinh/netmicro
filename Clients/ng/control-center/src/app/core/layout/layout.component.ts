import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { SidenavComponent } from './sidenav/sidenav.component';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';
import { MENU_ITEMS } from './pages-menu';
import { NbMenuItem, NbSidebarService } from '@nebular/theme';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isAuthorized$: Observable<any>;
  items: NbMenuItem[] = [];

  constructor(
    public authService: AuthService,
    private sidebarService: NbSidebarService,
  ) {}

  ngOnInit() {
    this.isAuthorized$ = this.authService.getIsAuthorized();
    this.items = MENU_ITEMS;
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

  toggleSideNav() {
    this.sidebarService.toggle(true, 'menu-sidebar');
    return false;
  }
}
