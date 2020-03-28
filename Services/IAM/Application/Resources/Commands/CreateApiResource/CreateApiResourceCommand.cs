using MediatR;
using Nmro.IAM.Application.Resources.Models;
namespace Nmro.IAM.Application.Resources.Commands
{
    public class CreateApiResourceCommand: IRequest<long>
    {
        public ApiResource Model;
    }
}
