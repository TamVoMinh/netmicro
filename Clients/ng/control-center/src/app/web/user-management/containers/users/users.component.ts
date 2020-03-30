import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser, IHttpResponse } from '@shared/common/_model';
import { Store, select } from '@ngrx/store';
import { selectUsersList } from '@app/core/store/selectors/user.selector';
import { GetUsers } from '@app/core/store/actions/user.action';

@Component({
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users$: Observable<IHttpResponse<IUser[]>> = this.store.pipe(select(selectUsersList));

  constructor(
    private store: Store,
  ) { }

  ngOnInit() {
    this.store.dispatch(new GetUsers({ email: '', limit: 50, offset: 0 }));
  }

  getUsers(event: any) {
    this.store.dispatch(new GetUsers({ limit: event.pageSize, offset: event.pageIndex, email: event.email }));
  }
}
