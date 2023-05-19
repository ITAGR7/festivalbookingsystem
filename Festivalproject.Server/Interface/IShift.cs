using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface;

public interface IShifts
{
    List<Shift> GetAllShifts();
    List<Shift> GetShiftsByStatus(bool status);
    Shift UpdateShift(Shift shift);
    Shift GetShiftById(string id);
}