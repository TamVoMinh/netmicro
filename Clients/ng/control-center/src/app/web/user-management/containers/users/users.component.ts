import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '@shared/common/_model';
import { Store, select } from '@ngrx/store';
import { selectUsersList } from '@app/core/store/selectors/user.selector';
import { GetUsers } from '@app/core/store/actions/user.action';

@Component({
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users$: Observable<IUser[]> = this.store.pipe(select(selectUsersList));

  constructor(
    private store: Store,
  ) { }

  ngOnInit() {
    this.store.dispatch(new GetUsers());
  }

}
