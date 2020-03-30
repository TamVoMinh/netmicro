import { Injectable } from '@angular/core';
import { ClientService } from '@app/shared/common';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { GetClients, EClientActions, GetClientSuccess } from '../actions/client.action';
import { map, switchMap } from 'rxjs/operators';
import { IClient } from '@app/shared/common/_model/client.interface';
import { of } from 'rxjs';
import { IHttpResponse } from '@app/shared/common/_model/http-response.interface';

@Injectable()
export class ClientEffect {
  constructor(
    private clientService: ClientService,
    private action$: Actions
  ) { }

  @Effect()
  clients$ = this.action$.pipe(
    ofType<GetClients>(EClientActions.GetClients),
    map(action => action.payload),
    switchMap(params => this.clientService.getClientList(params)),
    switchMap((res: IHttpResponse<IClient[]>) => of(new GetClientSuccess({ total: res.total, data: res.data })))
  )
}
