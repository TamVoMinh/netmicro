using MediatR;
using Nmro.Security.IAM.Core.UseCases.Clients.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.Clients.Queries
{
    public class FilterClientsByNameQuery: IRequest<PageClient>
    {
        public string Name {get; set;}

        public int Offset {get; set;}

        public int Limit {get; set;}
    }
}
