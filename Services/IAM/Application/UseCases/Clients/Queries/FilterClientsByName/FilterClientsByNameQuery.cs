using MediatR;
namespace Nmro.IAM.Application.UseCases.Clients.Queries
{
    public class FilterClientsByNameQuery: IRequest<ListResult<Models.Client>>
    {
        public string Name {get; set;}

        public int Offset {get; set;}

        public int Limit {get; set;}
    }
}
