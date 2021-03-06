using MediatR;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Commands
{
    public class UpdateApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId {get; set;}
        public Dtos.ApiResource Model {get; set;}
    }
}
