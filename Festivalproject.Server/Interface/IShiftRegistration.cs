using Festivalproject.Client.Services;
using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IShiftRegistration
    {
        List<ShiftRegistration> GetRegisteredShiftsById(string UserId); 
    }
}
