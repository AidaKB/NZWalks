using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {

                    var roleResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (roleResult.Succeeded)
                    {
                        return Ok("user regisstered successfuly");
                    }
                }
                return Ok("user regisstered successfuly! Now Login");
            }
            return BadRequest("something wrong with username or password! please try again");

        }
    }
}
