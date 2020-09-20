using MediatR;
using Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Commands
{
    public class CreateApiResourceCommand: IRequest<long>
    {
        public ApiResource Model;
    }
}
