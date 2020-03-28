using MediatR;

namespace Nmro.IAM.Application.Clients.Queries
{
    public class GetClientByClientIdQuery: IRequest<Models.Client> {
        public string ClientId { get; set;}
    }
}
