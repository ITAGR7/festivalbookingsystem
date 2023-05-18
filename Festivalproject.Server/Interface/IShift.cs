using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IShifts
    {
        List<Shift> GetAllShifts();
        List<Shift> GetShiftsByStatus(bool status);
        Task<Shift> UpdateShift(Shift shift); 
    }
}
