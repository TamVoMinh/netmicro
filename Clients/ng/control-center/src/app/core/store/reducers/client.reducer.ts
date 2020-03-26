import { IClientState } from '../states/client.state';
import { ClientActions, EClientActions } from '../actions/client.action';

export const clientReducers = (state: IClientState, actions: ClientActions): IClientState => {
  switch (actions.type) {
    case EClientActions.GetClientSuccess:
      return {
        ...state,
        clients: actions.payload
      }
    default:
      return state;
  }
}
