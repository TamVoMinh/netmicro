import { Action } from '@ngrx/store';
import { IUser, IHttpResponse } from '@shared/common/_model';

export enum EUserActions {
  GetUsers = '[User] Get Users',
  GetUsersSuccess = '[User] Get Users Success'
}

export class GetUsers implements Action {
  public readonly type = EUserActions.GetUsers;
  constructor(public payload: any) {}
}

export class GetUsersSuccess implements Action {
  public readonly type = EUserActions.GetUsersSuccess;
  constructor(public payload: IHttpResponse<IUser[]>) { }
}

export type UserActions = GetUsers | GetUsersSuccess;
