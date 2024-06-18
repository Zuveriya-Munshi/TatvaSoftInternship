using Business_logic_Layer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            try
            {
                await _userService.ForgotPasswordAsync(request.Email, request.BaseUrl);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _userService.ResetPasswordAsync(request.Token, request.NewPassword);
            if (result)
            {
                return Ok();
            }
            return BadRequest(new { message = "Invalid token or token expired" });
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
        public string BaseUrl { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
