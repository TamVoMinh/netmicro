import { Action } from '@ngrx/store';

export enum ELoadingAction {
  SHOW_LOADING = "[LOADING] SHOW_LOADING",
  HIDE_LOADING = "[LOADING] HIDE_LOADING",
}

export class ShowLoading implements Action {
  public readonly type = ELoadingAction.SHOW_LOADING
}

export class HideLoading implements Action {
  public readonly type = ELoadingAction.HIDE_LOADING
}

export type LoadingActions = ShowLoading | HideLoading;
