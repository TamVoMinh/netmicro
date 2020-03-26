using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using System;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Application.Users.Commands
{
    public class UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, (long, DateTime)>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;
        public UpsertUserCommandHandler(IIAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        public async Task<(long, DateTime)> Handle(UpsertUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser identityUser;
            if (request.Id.HasValue)
            {
                identityUser = await _context.IdentityUsers.FindAsync(request.Id.Value);

                if(false == string.IsNullOrEmpty(request.Password)){
                    identityUser.Salt = _passwordValidator.GenerateSalt();
                    identityUser.Password = _passwordValidator.HashWithPbkdf2(request.Password, identityUser.Salt);
                }

                if(false == string.IsNullOrEmpty(request.Email)){
                    identityUser.Email = request.Email;
                }
            }
            else
            {
                byte[] salt = _passwordValidator.GenerateSalt();
                identityUser = new IdentityUser{
                    Email = request.Email,
                    Password = _passwordValidator.HashWithPbkdf2(request.Password, salt),
                    Salt = salt
                };

                _context.IdentityUsers.Add(identityUser);
            }

            int count = await _context.SaveChangesAsync(cancellationToken);

            return count > 0 ? (identityUser.Id, identityUser.UpdatedDate) : (long.MinValue, DateTime.MinValue);
        }
    }
}
