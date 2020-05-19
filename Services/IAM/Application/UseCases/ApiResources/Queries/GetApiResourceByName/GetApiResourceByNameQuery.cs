using MediatR;
namespace Nmro.IAM.Application.UseCases.ApiResources.Queries
{
    public class GetApiResourceByNameQuery: IRequest<Models.ApiResource> {
        public string Name { get; set;}
    }
}
