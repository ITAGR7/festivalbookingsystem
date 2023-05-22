using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services;

public interface IShiftService
{
    Task<List<Shift>> GetAllShifts();

    Task<Shift> CreateShift(Shift shift);
 
    
    Task<Shift> GetShiftById(string id);

    Task<bool> DeleteShift(string id);    

    Task<Shift> UpdateShift(Shift _shift);


    
}
