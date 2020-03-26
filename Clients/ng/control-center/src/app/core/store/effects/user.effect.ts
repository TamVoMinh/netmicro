import { Injectable } from '@angular/core';
import { Effect, ofType, Actions } from '@ngrx/effects';
import { GetUsers, EUserActions, GetUsersSuccess } from '../actions/user.action';
import { switchMap, map } from 'rxjs/operators';
import { UserService } from '@shared/common/_service/user/user.service';
import { of } from 'rxjs';
import { IUser, IHttpResponse } from '@app/shared/common/_model';

@Injectable()
export class UserEffect {
  constructor(
    private userService: UserService,
    private action$: Actions,
  ) { }

  @Effect()
  users$ = this.action$.pipe(
    ofType<GetUsers>(EUserActions.GetUsers),
    map(action => action.payload),
    switchMap(params => this.userService.getUsersList(params)),
    switchMap((res: IHttpResponse<IUser[]>) => of(new GetUsersSuccess({ total: res.total, data: res.data })))
  )
}
