using MediatR;
using Nmro.IAM.Application.UseCases.ApiResources.Models;
namespace Nmro.IAM.Application.UseCases.ApiResources.Commands
{
    public class CreateApiResourceCommand: IRequest<long>
    {
        public ApiResource Model;
    }
}
