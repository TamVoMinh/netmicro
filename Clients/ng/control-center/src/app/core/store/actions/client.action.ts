import { Action } from '@ngrx/store';
import { IHttpResponse } from '@shared/common/_model';
import { IClient } from '@app/shared/common/_model/client.interface';

export enum EClientActions {
  GetClients = '[Client] Get Clients',
  GetClientSuccess = '[Client] Get Clients Success'
}

export class GetClients implements Action {
  public readonly type = EClientActions.GetClients;
  constructor(public payload: any) { }
}

export class GetClientSuccess implements Action {
  public readonly type = EClientActions.GetClientSuccess;
  constructor(public payload: IHttpResponse<IClient[]>) { }
}

export type ClientActions = GetClients | GetClientSuccess;


