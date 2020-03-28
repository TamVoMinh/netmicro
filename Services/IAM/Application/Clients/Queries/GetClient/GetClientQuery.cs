using MediatR;

namespace Nmro.IAM.Application.Clients.Queries
{
    public class GetClientQuery: IRequest<Models.Client> {
        public int Id { get; set;}
    }
}
