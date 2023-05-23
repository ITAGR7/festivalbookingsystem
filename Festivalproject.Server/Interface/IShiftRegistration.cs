
using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface;

public interface IShiftRegistration
{
    List<ShiftRegistration> GetRegisteredShiftsById(string UserId);

    Task<bool> UpdateShiftRegistrationByShiftId(Shift shift);

    Task<bool> CreateShiftRegistration(ShiftRegistration shiftRegistration);
}