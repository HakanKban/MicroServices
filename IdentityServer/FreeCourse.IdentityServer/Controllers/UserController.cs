using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser { UserName = signUpDto.UserName, Email = signUpDto.Email };
            var res = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!res.Succeeded == false)
            {
                return BadRequest(ResponseDTO<NoContent>.Fail(res.Errors.Select(x => x.Description).ToList(),400));
            }
            return Ok();
        }
    }
}
