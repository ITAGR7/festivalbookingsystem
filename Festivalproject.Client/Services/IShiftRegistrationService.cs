using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services
{
    public interface IShiftRegistrationService
    {
        public Task<ShiftRegistration> GetRegisteredShiftsById(string UserId); 
    }
}
