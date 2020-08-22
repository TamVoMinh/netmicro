using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Queries
{
    public class GetApiResourceByNameQuery: IRequest<Dtos.ApiResource> {
        public string Name { get; set;}
    }
}
