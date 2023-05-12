using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Interface
{
    public interface IShifts
    {
        List<Shifts> GetAllShifts();
        List<Shifts> GetShiftsByStatus(bool status);
    }
}
