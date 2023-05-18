using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IUser
    {

        List<User> GetAllUsers();
        User CreateUser(User newUser);

        LoginResultDTO GetLoginResult(string username, string password);

        User GetUserByObjectId(string id); 

        //int PostUser(User user);

        //void DeleteUser(int userid);

        Task<bool> UpdateUser(User userUpdated);

    }

}