using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services
{
    public interface IShiftRegistrationService
    {
        public Task<List<ShiftRegistration>> GetRegisteredShiftsById(string UserId);  //Ændrede denne til liste - eftersom denne stod med returtype shiftregistration 

        public Task<bool> UpdateShiftRegistrationByShiftId(Shift shift);

        public Task CreateShiftRegistration(ShiftRegistration shiftregistration);

    }
}



   
   
