using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.UseCases.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        public DeleteUserCommandHandler(IIAMDbcontext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
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
