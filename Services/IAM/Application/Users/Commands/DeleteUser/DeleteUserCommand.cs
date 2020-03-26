using System;
using MediatR;
namespace Nmro.IAM.Application.Users.Commands
{
    public class DeleteUserCommand: IRequest<(long, DateTime)> {
        public long Id{ get; set; }
    }
}
