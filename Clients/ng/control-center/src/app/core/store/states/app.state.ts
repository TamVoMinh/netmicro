import { IUserState, initialUserState } from './user.state';
import { RouterReducerState } from '@ngrx/router-store';
import { ILoadingState, initialLoadingState } from './loading.state';

export interface IAppState {
  router?: RouterReducerState
  users: IUserState;
  loading: ILoadingState
}

export const initialAppState: IAppState = {
  users: initialUserState,
  loading: initialLoadingState
}

export function getInitialState(): IAppState {
  return initialAppState;
}
