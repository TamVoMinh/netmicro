import { IUser, IHttpResponse } from '@shared/common/_model';

export interface IUserState {
  users: IHttpResponse<IUser[]>;
}

export const initialUserState: IUserState = {
  users: {
    total: 0,
    data: []
  }
}
