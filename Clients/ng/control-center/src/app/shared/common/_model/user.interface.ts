export interface IUser {
  id: number;
  username: string;
  email: string;
  isDeleted: boolean;
  createdDate: Date;
  updatedDate: Date;
  createBy: string;
  updateBy: string;
  title: string;
}
