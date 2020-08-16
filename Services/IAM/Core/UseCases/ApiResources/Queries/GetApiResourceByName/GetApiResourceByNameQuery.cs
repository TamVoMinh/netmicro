using MediatR;
namespace Nmro.IAM.Core.UseCases.ApiResources.Queries
{
    public class GetApiResourceByNameQuery: IRequest<Models.ApiResource> {
        public string Name { get; set;}
    }
}
