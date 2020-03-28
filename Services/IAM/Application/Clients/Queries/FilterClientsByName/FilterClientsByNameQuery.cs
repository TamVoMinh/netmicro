using MediatR;
namespace Nmro.IAM.Application.Clients.Queries
{
    public class FilterClientsByNameQuery: IRequest<ResponseListResult<Models.Client>>
    {
        public string Name {get; set;}

        public int Offset {get; set;}

        public int Limit {get; set;}
    }
}
