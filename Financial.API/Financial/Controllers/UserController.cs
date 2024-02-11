using Financial.Data.DTOs;
using Financial.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Web.Controllers
{
    [Authorize(Policy = "Access")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _username = "";
        private readonly IAuthenticationService _authenticationService;

        public UserController(
            IHttpContextAccessor httpContextAccesso,
            IAuthenticationService authenticationService
            )
        {
            _httpContextAccessor = httpContextAccesso;
            _authenticationService = authenticationService;
        }
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            this._username = this._httpContextAccessor?.HttpContext?.Request.Headers["user"].SingleOrDefault() ?? "";
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (!string.IsNullOrWhiteSpace(login.Username))
            {
                var authenticationtoken = _authenticationService.AuthenticateUser(login.Username);

                if (!string.IsNullOrEmpty(authenticationtoken))
                {
                    return Ok(new { Token = authenticationtoken, StatusCode = 200 });
                }
                else
                {
                    return Unauthorized();
                }
            }
            return Unauthorized();
        }
    }
}
