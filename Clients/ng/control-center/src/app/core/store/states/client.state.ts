import { IClient } from '@app/shared/common/_model/client.interface';
import { IHttpResponse } from '@app/shared/common/_model/http-response.interface';

export interface IClientState {
  clients: IHttpResponse<IClient[]>;
}

export const initialClientState: IClientState = {
  clients: {
    total: 0,
    data: []
  }
}
