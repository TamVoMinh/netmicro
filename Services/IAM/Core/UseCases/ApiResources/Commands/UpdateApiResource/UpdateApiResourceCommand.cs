using MediatR;
namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
{
    public class UpdateApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId {get; set;}
        public Models.ApiResource Model {get; set;}
    }
}
