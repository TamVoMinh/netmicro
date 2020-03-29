using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Nmro.Blocks.Interfaces;

namespace Nmro.IAM.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string stringUserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = 0;
            UserId  = string.IsNullOrWhiteSpace(stringUserId)? int.MinValue :  int.TryParse(stringUserId, out id) ? id : int.MinValue;

            IsAuthenticated = UserId > 0;
        }

        public int UserId { get; }

        public string UuId {get;}

        public bool IsAuthenticated { get; }


    }
}
