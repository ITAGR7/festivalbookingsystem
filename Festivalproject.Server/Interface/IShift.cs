using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IShift
    {
        List<Shift> GetAllShifts();
        List<Shift> GetShiftsByStatus(bool status);
    }
}
