using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IUser
    {

        public List<User> GetAllUsers();
        public string CreateUser(User newUser);

        public LoginResult GetLoginResult(string username, string password);

        public User GetUserById(string id); 

        //int PostUser(User user);

        //void DeleteUser(int userid);

        public Task<bool> UpdateUser(User userUpdated);

    }

}