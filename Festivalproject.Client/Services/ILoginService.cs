using Festivalproject.Shared.Models;

namespace Festivalproject.Client.Services;

public interface ILoginService
{
    public Task<LoginResultDTO> GetLoginResult(LoginDataDTO loginData);
}