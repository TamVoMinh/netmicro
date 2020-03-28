using MediatR;
namespace Nmro.IAM.Application.Resources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<ResponseListResult<Models.IdentityResource>> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
