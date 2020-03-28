using MediatR;
using Nmro.IAM.Application.UseCases.Resources.Models;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class CreateApiResourceCommand: IRequest<long>
    {
        public ApiResource Model;
    }
}
