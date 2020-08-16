using MediatR;

namespace Nmro.IAM.Core.UseCases.Clients.Queries
{
    public class GetClientQuery: IRequest<Models.Client> {
        public int Id { get; set;}
    }
}
