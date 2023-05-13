using Festivalproject.Shared.Models;

namespace Festivalproject.Client.Services
{
    public interface ILoginService
    {
        public Task<LoginResult> GetLoginResult(string username, string password);   
    }
}
