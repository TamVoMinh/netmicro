using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Nmro.Portal.Landing.Controllers
{
    [Authorize(AuthenticationSchemes = "oidc")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(AuthenticationSchemes = "oidc")]
        public Task<RedirectToActionResult> SignIn(string returnUrl)
        {
            return Task.FromResult(RedirectToAction(nameof(HomeController.Index), "Home"));
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            var homeUrl = Url.Action(nameof(HomeController.Index), "Home");

            return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,new AuthenticationProperties { RedirectUri = homeUrl });
        }
    }
}
