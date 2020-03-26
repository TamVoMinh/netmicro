import { IHttpResponse } from '@app/shared/common';
import { IClient } from '@app/shared/common/_model/client.interface';

export interface IClientState {
  clients: IHttpResponse<IClient[]>;
}

export const initialClientState: IClientState = {
  clients: {
    total: 0,
    data: []
  }
}
