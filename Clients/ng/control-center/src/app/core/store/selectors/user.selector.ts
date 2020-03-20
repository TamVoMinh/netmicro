import { createSelector } from '@ngrx/store';
import { IUserState } from '../states/user.state';
import { IAppState } from '../states/app.state';

const selectUsers = (state: IAppState) => state.users;

export const selectUsersList = createSelector(
  selectUsers,
  (state: IUserState) => state.users
);
