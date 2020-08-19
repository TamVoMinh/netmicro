using MediatR;

namespace Nmro.Security.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientQuery: IRequest<Dtos.Client> {
        public int Id { get; set;}
    }
}
