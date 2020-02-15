using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Nmro.Oidc.Application;
using Nmro.Oidc.Infrastructure;
using Nmro.Oidc.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace Nmro.Oidc.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        //private readonly HttpClient _apiClient;
        private readonly IUserService _userService;
        private readonly IOptions<AppSettings> _settings;
        //private readonly ILogger _logger;

        private readonly string _identityUrl;

        public ResourceOwnerPasswordValidator(IUserService userService, IConfiguration configuration, IOptions<AppSettings> settings)
        {
            _settings = settings;
            _userService = userService;

            _identityUrl = $"{_settings.Value.IdentityApiEndpoint}";
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _userService.FindByUsername(context.UserName);
                if (user != null)
                {
                    var result = await _userService.ValidateCredentials(context.UserName, context.Password);
                    if (result)
                    {
                        Log.Information($"Credentials validated for username: {context.UserName}");
                        context.Result = new GrantValidationResult(user.Id.ToString(), AuthenticationMethods.Password);
                        return;
                    }
                    else
                    {
                        Log.Information($"Authentication failed for username: {context.UserName}; Reason: invalid credentials");
                        //await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid credentials", interactive: false));
                    }
                }
                else
                {
                    Log.Information($"No user found matching username: {context.UserName}");
                    //await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid username", interactive: false));
                }

                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);

            }
            catch (HttpRequestException httpEx)
            {
                Log.Debug($"HttpRequestException: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Log.Debug($"Exception: {ex.Message}");
            }
        }
    }
}

