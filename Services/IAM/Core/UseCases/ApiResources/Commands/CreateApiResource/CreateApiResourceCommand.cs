using MediatR;
using Nmro.IAM.Core.UseCases.ApiResources.Models;
namespace Nmro.IAM.Core.UseCases.ApiResources.Commands
{
    public class CreateApiResourceCommand: IRequest<long>
    {
        public ApiResource Model;
    }
}
