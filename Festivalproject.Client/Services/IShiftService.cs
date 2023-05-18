using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services
{
    public interface IShiftService
    {
        Task<List<Shift>> GetAllShifts(); 

        Task<Shift> CreateShift(Shift shift);

        Task DeleteShift(string id);    

    }
}
