using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Koy.Blog.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            var issuer = "http://viranovin.com";
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Behrang", ClaimValueTypes.String, issuer),
                new Claim("Id", "453", ClaimValueTypes.Double, issuer)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    AllowRefresh = false,
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(5)
                });
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }

    }
}