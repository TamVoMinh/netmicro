using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;
namespace Nmro.IAM.Application.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IIAMDbcontext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;
        public DeleteUserCommandHandler(IIAMDbcontext context, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
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
