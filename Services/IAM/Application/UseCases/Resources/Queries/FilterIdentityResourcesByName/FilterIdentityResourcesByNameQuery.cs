using MediatR;
namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class FilterIdentityResourcesByNameQuery: IRequest<ListResult<Models.IdentityResource>> {
        public string Name { get; set;}
        public int Limit { get; set;}
        public int Offset { get; set;}
    }
}
