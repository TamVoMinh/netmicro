using MediatR;
using Nmro.IAM.Application.UseCases.Clients.Models;

namespace Nmro.IAM.Application.UseCases.Clients.Queries
{
    public class FilterClientsByNameQuery: IRequest<PageClient>
    {
        public string Name {get; set;}

        public int Offset {get; set;}

        public int Limit {get; set;}
    }
}
