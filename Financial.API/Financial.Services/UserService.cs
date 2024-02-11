using Financial.Data;
using Financial.Data.Models;
using Financial.Services.Interfaces;

namespace Financial.Services
{
    public class UserService : IUserService
    {
        private readonly FinancialDbContext _financialDbContext;
        public UserService(FinancialDbContext financialDbContext)
        {
            _financialDbContext = financialDbContext;
        }

        public User GetOrCreateUser(string username)
        {
            var user = _financialDbContext.Users.FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                user = new User(username);
                _financialDbContext.Users.Add(user);
                _financialDbContext.SaveChanges();
            }
            return user;
        }
    }
}
