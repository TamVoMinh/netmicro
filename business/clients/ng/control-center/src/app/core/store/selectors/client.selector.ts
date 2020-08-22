import { createSelector } from '@ngrx/store';
import { IAppState, getInitialState } from "../states/app.state";
import { IClientState } from '../states/client.state';

const clientState = (state: IAppState) => state.clients;

export const selectClientList = createSelector(
  clientState,
  (state: IClientState) => state.clients
);
