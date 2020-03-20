import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { ShowLoading, ELoadingAction, HideLoading } from '../actions/loading.action';
import { map } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { Action } from '@ngrx/store';

@Injectable()
export class LoadingEffect {
  constructor(
    private action$: Actions
  ) { }

  @Effect()
  showLoading$ = this.action$.pipe(
    ofType<ShowLoading>(ELoadingAction.SHOW_LOADING),
    map(() => new ShowLoading())
  )

  @Effect()
  hideLoading$ = this.action$.pipe(
    ofType<HideLoading>(ELoadingAction.HIDE_LOADING),
    map(() => new HideLoading())
  )
}
