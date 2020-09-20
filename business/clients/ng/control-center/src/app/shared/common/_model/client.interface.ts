export interface IClient {
  allowedScopes: string[],
  clientId: string;
  clientName: string;
  allowedGrantTypes: string[],
  requiredPkce: boolean;
  createdDate: Date;
}
