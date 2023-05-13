using Festivalproject.Shared.Models; 

namespace Festivalproject.Client.Services
{
    public interface IUserService
    {
        public Task<User> GetUserById(string id);
        public void CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(string id);

        //public Task<LoginResult> IsValidLogin(string username, string password);
    }
}

