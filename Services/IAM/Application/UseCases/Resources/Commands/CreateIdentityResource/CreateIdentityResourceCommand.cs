using MediatR;
using Nmro.IAM.Application.UseCases.Resources.Models;
namespace Nmro.IAM.Application.UseCases.Resources.Commands
{
    public class CreateIdentityResourceCommand: IRequest<int>
    {
        public IdentityResource Model;
    }
}
