using Financial.Services.Interfaces;

namespace Financial.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }
        public string AuthenticateUser(string username)
        {
            var user = _userService.GetOrCreateUser(username);
            var token = "";
            if (user != null)
            {
                token = GenerateTokenForUser(user.Name);
            };
            return token;
        }

        public string GenerateTokenForUser(object username)
        {
            //Use a real token generation library here like JWT if there is enough time

            return "generated_token";
        }
    }
}
