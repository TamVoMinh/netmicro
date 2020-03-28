using MediatR;

namespace Nmro.IAM.Application.UseCases.Clients.Queries
{
    public class GetClientQuery: IRequest<Models.Client> {
        public int Id { get; set;}
    }
}
