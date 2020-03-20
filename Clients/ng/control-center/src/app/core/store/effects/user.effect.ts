import { Injectable } from '@angular/core';
import { Effect, ofType, Actions } from '@ngrx/effects';
import { GetUsers, EUserActions, GetUsersSuccess } from '../actions/user.action';
import { switchMap } from 'rxjs/operators';
import { UserService } from '@shared/common/_service/user/user.service';
import { of } from 'rxjs';
import { Store } from '@ngrx/store';
import { ShowLoading, HideLoading } from '../actions/loading.action';

@Injectable()
export class UserEffect {
  constructor(
    private userService: UserService,
    private action$: Actions,
    private store: Store
  ) { }

  @Effect()
  users$ = this.action$.pipe(
    ofType<GetUsers>(EUserActions.GetUsers),
    switchMap(() => {
      this.store.dispatch(new ShowLoading());
      return this.userService.getUsersList()
    }),
    switchMap((res) => {
      this.store.dispatch(new HideLoading());
      return of(new GetUsersSuccess(res.users))
    })
  )
}
