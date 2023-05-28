using Festivalproject.Shared.Models;
using MongoDB.Driver;

namespace Festivalproject.Server.Interface;

public interface IUser
{
    List<User> GetAllUsers();
    User CreateUser(User newUser);

    LoginResultDTO GetLoginResult(string username, string password);

    User GetUserByObjectId(string id);

    Task<UpdateResult> UpdateUser(User userUpdated);
}