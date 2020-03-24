import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '@app/shared/common/_model';
import { Store } from '@ngrx/store';
import { ShowLoading } from '@app/core/store/actions/loading.action';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  @Input() users: Observable<IUser[]>;
  constructor(
    private store: Store
  ) { }

  ngOnInit() {
  }
}
