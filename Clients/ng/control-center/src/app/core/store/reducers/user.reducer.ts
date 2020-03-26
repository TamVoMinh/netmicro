import { initialUserState, IUserState } from '../states/user.state';
import { UserActions, EUserActions } from '../actions/user.action';

export const userReducers = (state: IUserState = initialUserState, action: UserActions): IUserState => {
  switch(action.type) {
    case EUserActions.GetUsersSuccess:
      return {
        ...state,
        users: action.payload
      }
    default:
      return state;
  }
}
