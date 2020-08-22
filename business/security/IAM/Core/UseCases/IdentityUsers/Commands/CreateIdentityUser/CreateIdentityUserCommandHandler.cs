using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.Entities;
namespace Nmro.Security.IAM.Core.UseCases.Users.Commands
{
    public class CreateIdentityUserCommandHandler : IRequestHandler<CreateIdentityUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;
        public CreateIdentityUserCommandHandler(IIAMDbcontext context, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _passwordProcessor = passwordValidator;
        }
        public async Task<int> Handle(CreateIdentityUserCommand request, CancellationToken cancellationToken)
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
