using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Application.Users.Models;

namespace Nmro.IAM.Application.Users.Queries
{
    public class ValidateCredentialQueryHandler : IRequestHandler<ValidateCredentialQuery, IdentityUserModel>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordProcessor _passwordProcessor;

        public ValidateCredentialQueryHandler(IIAMDbcontext context, IMapper mapper, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _mapper = mapper;
            _passwordProcessor = passwordValidator;
        }

        public async Task<IdentityUserModel> Handle(ValidateCredentialQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.IdentityUsers.FirstOrDefaultAsync(x => x.UserName == request.Credential.UserName);
            if(user == null){
                return null;
            }

            var result = _passwordProcessor.VerifyHashedPassword(user.Password, request.Credential.Password, user.Salt);

            return (result == PasswordVerificationResult.Success)
                ? _mapper.Map<IdentityUserModel>(user)
                : null;
        }
    }
}
