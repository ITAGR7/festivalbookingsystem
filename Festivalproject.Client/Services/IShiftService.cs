using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services;

public interface IShiftService
{
    Task<List<Shift>> GetAllShifts();

    Task<Shift> CreateShift(Shift shift);

    Task DeleteShift(string id);
    
    Task<Shift> UpdateShift(Shift shiftUpdated);
    
    Task<Shift> GetShiftById(string id);
}