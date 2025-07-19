using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel credentials)
        {
            try
            {
                if (ModelState.IsValid && await DoLogin(credentials))
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { IsAuthenticated = true });
            }
            return Unauthorized(new { IsAuthenticated = false });
        }

        private async Task<bool> DoLogin(LoginViewModel credentials)
        {
            var user = await userManager.FindByNameAsync(credentials.Username);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                var result = await signInManager.PasswordSignInAsync(user, credentials.Password, false, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}
