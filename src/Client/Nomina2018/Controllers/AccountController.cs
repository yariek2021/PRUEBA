using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DomainLayer;
using DtoLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomina2018.ViewModels;
using ServiceLayer;

namespace Nomina2018.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public AccountController(ILogger<AccountController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("/account/login")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [Route("/account/login")]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
     
            if (ModelState.IsValid)
            {

                var user = await _userService.Authenticate(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido");
                }
                else
                {
                    await SignInUser(user, model.RememberMe);
                    return Redirect(model.ReturnUrl ?? "~/");

                }
            }

            return View();
        }

        private async Task SignInUser(UsuarioDto usuario, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, usuario.Alias));
                claims.Add(new Claim(ClaimTypes.Role, usuario.Role));

                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdenties),authProperties);

            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }


        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult NewUser()
        {

            return View();
        }
        public async Task<IActionResult> Logout()
        {

            try
            {

                await HttpContext.SignOutAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Redirect("~/");
        }


    }
}