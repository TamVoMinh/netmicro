import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
  @Input() isAuthorized$: Observable<boolean>;
  @Output() toggle = new EventEmitter<any>();
  @Output() logout = new EventEmitter<any>();
  @Output() login = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  toggleSideBar() {
    this.toggle.emit();
  }
}
