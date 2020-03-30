import { createSelector } from '@ngrx/store';
import { IUserState } from '../states/user.state';
import { IAppState } from '../states/app.state';

const userState = (state: IAppState) => state.users;

export const selectUsersList = createSelector(
  userState,
  (state: IUserState) => state.users
);
