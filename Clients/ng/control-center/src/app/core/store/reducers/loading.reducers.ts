import { ILoadingState, initialLoadingState } from '../states/loading.state';
import { LoadingActions, ELoadingAction } from '../actions/loading.action';

export const loadingReducers = (state: ILoadingState = initialLoadingState, action: LoadingActions) => {
  switch(action.type) {
    case ELoadingAction.SHOW_LOADING:
      return {
        ...state,
        isShowLoading: true
      };
    case ELoadingAction.HIDE_LOADING:
      return {
        ...state,
        isShowLoading: false
      }
    default:
      return state;
  }
}
