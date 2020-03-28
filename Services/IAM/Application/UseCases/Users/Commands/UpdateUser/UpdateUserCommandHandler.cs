using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordProcessor _passwordProcessor;
        public UpdateUserCommandHandler(IIAMDbcontext context, IMapper mapper, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _mapper = mapper;
            _passwordProcessor = passwordValidator;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser identityUser = await _context.IdentityUsers.FindAsync(request.Model.Id);

            if(identityUser == null){
                return int.MinValue;
            }

            Models.UpdatingUserModel updating = request.Model;

            if(updating.Email.IsPresent()){
                identityUser.Email = updating.Email;
            }

            if(updating.Password.IsPresent()){
                byte[] salt = _passwordProcessor.GenerateSalt();
                identityUser.Salt = salt;
                identityUser.Password = _passwordProcessor.HashWithPbkdf2(request.Model.Password, salt);
            }


            _context.IdentityUsers.Add(identityUser);

            int count = await _context.SaveChangesAsync(cancellationToken);
            return count > 0 ? identityUser.Id : int.MinValue;
        }
    }
}
