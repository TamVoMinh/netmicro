using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.Aggregations.Queries
{
    public class ListAllResourcesQuery : IRequest<Dtos.AllResources>{}
}
