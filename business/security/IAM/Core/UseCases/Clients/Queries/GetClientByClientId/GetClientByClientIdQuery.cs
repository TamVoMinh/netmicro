using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientByClientIdQuery: IRequest<Dtos.Client> {
        public string ClientId { get; set;}
    }
}
