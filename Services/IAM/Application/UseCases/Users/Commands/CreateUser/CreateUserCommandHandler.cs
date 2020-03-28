using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;
        public CreateUserCommandHandler(IIAMDbcontext context, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _passwordProcessor = passwordValidator;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser identityUser;


            byte[] salt = _passwordProcessor.GenerateSalt();
            identityUser = new IdentityUser{
                Email = request.Model.Verifier.Email,
                Password = _passwordProcessor.HashWithPbkdf2(request.Model.Password, salt),
                Salt = salt
            };
            _context.IdentityUsers.Add(identityUser);

            int count = await _context.SaveChangesAsync(cancellationToken);
            return count > 0 ? identityUser.Id : int.MinValue;
        }
    }
}
