import { IUser } from '@shared/common/_model';

export interface IUserState {
  users: IUser[];
}

export const initialUserState: IUserState = {
  users: []
}
