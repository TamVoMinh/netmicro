using MediatR;

namespace Nmro.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientByClientIdQuery: IRequest<Models.Client> {
        public string ClientId { get; set;}
    }
}
