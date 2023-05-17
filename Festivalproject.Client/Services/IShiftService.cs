using Festivalproject.Shared.Models;

namespace Festivalproject.Client.Services
{
    public interface IShiftService
    {
        public Task <List<Shifts>> GetAllShifts();
        public void CreateShift(Shifts shift);
        public Task UpdateShift(Shifts shift);
        public Task DeleteShift(string id);

        //public Task<LoginResult> IsValidLogin(string username, string password);
    }
}

