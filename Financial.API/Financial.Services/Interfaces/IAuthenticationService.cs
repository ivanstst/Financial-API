namespace Financial.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string AuthenticateUser(string username);

        string GenerateTokenForUser(object username);
    }
}
