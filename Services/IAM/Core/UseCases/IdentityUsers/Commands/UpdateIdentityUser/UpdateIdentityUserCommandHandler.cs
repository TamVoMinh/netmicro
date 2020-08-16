using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Core.UseCases.Users.Dtos;
using Nmro.Common.Extentions;
namespace Nmro.IAM.Core.UseCases.Users.Commands
{
    public class UpdateIdentityUserCommandHandler : IRequestHandler<UpdateIdentityUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IPasswordProcessor _passwordProcessor;
        public UpdateIdentityUserCommandHandler(IIAMDbcontext context, IPasswordProcessor passwordValidator)
        {
            _context = context;
            _passwordProcessor = passwordValidator;
        }
        public async Task<int> Handle(UpdateIdentityUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _context.IdentityUsers.FindAsync(request.Model.Id);

            if(identityUser == null){
                return int.MinValue;
            }

            UpdatingUserModel updating = request.Model;

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
