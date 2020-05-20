using MediatR;
namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class DeleteIdentityUserCommand: IRequest<int> {
        public int Id{ get; set; }
    }
}
