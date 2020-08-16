using MediatR;
namespace Nmro.IAM.Core.UseCases.Users.Commands
{
    public class DeleteIdentityUserCommand: IRequest<int> {
        public int Id{ get; set; }
    }
}
