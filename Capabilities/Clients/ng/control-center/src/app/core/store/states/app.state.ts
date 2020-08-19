import { IUserState, initialUserState } from './user.state';
import { RouterReducerState } from '@ngrx/router-store';
import { IClientState, initialClientState } from './client.state';

export interface IAppState {
  router?: RouterReducerState
  users: IUserState;
  clients: IClientState;
}

export const initialAppState: IAppState = {
  users: initialUserState,
  clients: initialClientState
}

export function getInitialState(): IAppState {
  return initialAppState;
}
