using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festivalproject.Server.Interface
{
    public interface IShifts
    {
        List<Shift> GetAllShifts();
        List<Shift> GetShiftsByStatus(bool status);
        Task<Shift> UpdateShift(Shift shift);
        Task<bool> DeleteShift(string id);
        Task<Shift> CreateShift(Shift shift);
        
        Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status);
    }
}
