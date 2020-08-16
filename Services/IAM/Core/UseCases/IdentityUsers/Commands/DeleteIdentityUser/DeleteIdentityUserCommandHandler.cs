using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Core.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Core.UseCases.Users.Commands
{
    public class DeleteIdentityUserCommandHandler : IRequestHandler<DeleteIdentityUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public DeleteIdentityUserCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteIdentityUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser identityUser = await _context.IdentityUsers.FindAsync(request.Id);
            if(identityUser == null){
                return int.MinValue;
            }
            identityUser.IsDeleted = true;
            _context.IdentityUsers.Update(identityUser);
            await _context.SaveChangesAsync(cancellationToken);
            return identityUser.Id;
        }
    }
}
