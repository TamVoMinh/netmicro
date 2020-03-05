import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  @Input() isAuthorized$: Observable<boolean>;
  @ViewChild('sidenav', { static: true }) sidenav: any;
  constructor() { }

  ngOnInit() {
  }

  toggleSideNav() {
    this.sidenav.toggle();
  }
}
