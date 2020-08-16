using MediatR;

namespace Nmro.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientByClientIdQuery: IRequest<Dtos.Client> {
        public string ClientId { get; set;}
    }
}
