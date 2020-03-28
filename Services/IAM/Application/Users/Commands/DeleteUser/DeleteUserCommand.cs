using MediatR;
namespace Nmro.IAM.Application.Users.Commands
{
    public class DeleteUserCommand: IRequest<int> {
        public int Id{ get; set; }
    }
}
