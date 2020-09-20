import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';
import { MENU_ITEMS } from './pages-menu';
import { NbMenuItem, NbSidebarService, NbMenuService, NbMenuBag } from '@nebular/theme';
import { filter } from 'rxjs/operators';

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
    private nbMenuService: NbMenuService
  ) {}

  ngOnInit() {
    this.isAuthorized$ = this.authService.getIsAuthorized();
    this.items = MENU_ITEMS;

    this.nbMenuService.onItemClick().pipe(
      filter((menuBag: NbMenuBag) => {
          return menuBag.item.title === 'Log out';
      })
    ).subscribe(() => {
      this.logout();
    })
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
