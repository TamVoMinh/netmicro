using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;
        public CreateUserCommandHandler(IIAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser identityUser;


            byte[] salt = _passwordValidator.GenerateSalt();
            identityUser = new IdentityUser{
                Email = request.Model.Verifier.Email,
                Password = _passwordValidator.HashWithPbkdf2(request.Model.Password, salt),
                Salt = salt
            };
            _context.IdentityUsers.Add(identityUser);

            int count = await _context.SaveChangesAsync(cancellationToken);
            return count > 0 ? identityUser.Id : int.MinValue;
        }
    }
}
