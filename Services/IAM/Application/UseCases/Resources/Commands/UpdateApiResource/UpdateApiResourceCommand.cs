using MediatR;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class UpdateApiResourceCommand: IRequest<int>
    {
        public int ApiResourceId {get; set;}
        public Models.ApiResource Model {get; set;}
    }
}
