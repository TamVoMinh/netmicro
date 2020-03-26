using System;
using MediatR;
namespace Nmro.IAM.Application.Users.Commands
{
    public class UpsertUserCommand: IRequest<(long, DateTime)> {
        public long? Id{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
