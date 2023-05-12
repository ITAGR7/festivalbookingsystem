using Festivalproject.Shared.Models; 

namespace Festivalproject.Client.Services
{
    public interface IUserService
    {
        public Task<User> GetUser(int userid);
        public void CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(int userid);

        public Task<bool> IsValidLogin(string username, string password);
    }
}

