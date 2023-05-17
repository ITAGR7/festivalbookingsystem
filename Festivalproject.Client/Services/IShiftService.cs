using Festivalproject.Shared.Models;

namespace Festivalproject.Client.Services
{
    public interface IShiftService
    {
        public Task <List<Shift>> GetAllShifts();
        public void CreateShift(Shift newShift);
        public Task UpdateShift(Shift updateshift);
        public Task DeleteShift(string id);

        //public Task<LoginResult> IsValidLogin(string username, string password);
    }
}

