using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Nmro.Common.Extentions;
namespace Nmro.Common.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ILogger<CurrentUserService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, ILogger<CurrentUserService> logger)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private int _userId = int.MinValue;
        public int UserId {
            get {
                if(_userId > 0) return _userId;

                string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

                _logger.LogTrace("Authorization->Access_Token: {0}", accessToken);

                if(accessToken.IsPresent())
                {
                    accessToken = accessToken.Replace("Bearer ", "");
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;

                    if(jsonToken.Subject!=null){
                        int.TryParse(jsonToken.Subject, out _userId);
                    }
                }

                return _userId;
            }
        }

        public string UuId {get;}

        public bool IsAuthenticated { get => _userId > 0 ; }

    }
}
