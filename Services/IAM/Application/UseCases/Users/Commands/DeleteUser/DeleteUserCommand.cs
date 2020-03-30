using MediatR;
namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand: IRequest<int> {
        public int Id{ get; set; }
    }
}
