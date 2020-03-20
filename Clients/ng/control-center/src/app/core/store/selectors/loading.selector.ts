import { createSelector } from '@ngrx/store';
import { IAppState } from '../states/app.state';
import { ILoadingState } from '../states/loading.state';

const selectLoadingFromAppState = (state: IAppState) => state.loading;

export const selectLoading = createSelector(
  selectLoadingFromAppState,
  (state: ILoadingState) => state.isLoading
)

