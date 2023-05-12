using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IUser
    {

        public List<User> GetAllUsers();
        public string CreateUser(User newUser);

        public bool IsValidLogin(string username, string password);

        //int PostUser(User user);

        //void DeleteUser(int userid);

        //void PutUser(User user);

    }

}