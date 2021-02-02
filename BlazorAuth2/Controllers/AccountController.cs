using BlazorAuth2.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;

namespace BlazorAuth2.Controllers
{
    [Route("Account/login")]
    public class AccountController : Controller
    {

        readonly SignInManager<IdentityUser> _signinManager;
        readonly UserManager<IdentityUser> _userManager;
        public AccountController(SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel value)
        {
            var result = await _signinManager.PasswordSignInAsync(value.Username, value.Password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(value.Username);

                if (user != null)
                {
                    await _signinManager.SignInAsync(user, true);

                    return Ok();
                }
            }

            return Ok();
        }
    }
}
