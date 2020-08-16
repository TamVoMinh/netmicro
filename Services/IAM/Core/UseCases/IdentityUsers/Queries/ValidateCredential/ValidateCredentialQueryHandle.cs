using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Users.Dtos;

namespace Nmro.IAM.Core.UseCases.Users.Queries
{
    public class ValidateCredentialQueryHandler : IRequestHandler<ValidateCredentialQuery, IdentityUser>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;

        public ValidateCredentialQueryHandler(IIAMDbcontext context, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _passwordProcessor = passwordValidator;
        }

        public async Task<IdentityUser> Handle(ValidateCredentialQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.Username == request.Username);
            if(user == null){
                return null;
            }

            var result = _passwordProcessor.VerifyHashedPassword(user.Password, request.Password, user.Salt);

            return (result == PasswordVerificationResult.Success)
                ? user.ToModel()
                : null;
        }
    }
}
