using Festivalproject.Shared.Models;

namespace Festivalproject.Client.Services;

public interface IUserService
{
    public Task<User> GetUserByObjectId(string id);
    public Task<User> CreateUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(string id);

}