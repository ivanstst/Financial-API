using Financial.Data.Models;

namespace Financial.Services.Interfaces
{
    public interface IUserService
    {
        User GetOrCreateUser(string username);
    }
}
