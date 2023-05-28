using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services;

public interface IShiftService
{
    public Task<List<Shift>> GetAllShifts();

    public Task<Shift> CreateShift(Shift shift);

    Task<bool> DeleteShift(string id);

    Task<Shift> UpdateShift(Shift _shift);

    Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status);
    
    Task<List<Shift>> GetShiftsByStatus(bool Status);
}