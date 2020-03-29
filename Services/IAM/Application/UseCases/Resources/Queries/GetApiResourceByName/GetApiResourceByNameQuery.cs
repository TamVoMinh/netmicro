using MediatR;
namespace Nmro.IAM.Application.UseCases.Resources.Queries
{
    public class GetApiResourceByNameQuery: IRequest<Models.ApiResource> {
        public string Name { get; set;}
    }
}
