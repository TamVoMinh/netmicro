import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { NbMenuItem, NbSidebarService } from '@nebular/theme';
import { MENU_ITEMS } from '../pages-menu';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  @Input() isAuthorized$: Observable<boolean>;

  items: NbMenuItem[] = [];

  constructor(
    private sidebarService: NbSidebarService,
  ) { }

  ngOnInit() {
    this.items = MENU_ITEMS;
  }

  toggleSideNav() {
    this.sidebarService.toggle(true);
    return false;
  }
}
