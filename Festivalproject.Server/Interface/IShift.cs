using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festivalproject.Server.Interface
{
    public interface IShifts
    {
        List<Shift> GetAllShifts();
        List<Shift> GetShiftsByStatus(bool status);
        Task<Shift> UpdateShift(Shift shift);
        Task<bool> DeleteShift(string id); //Lidt usikker på hvad for en returtype en delete vil have? Skal denne være task?
        Task<Shift> CreateShift(Shift shift);
    }
}
namespace Festivalproject.Server.Interface;

public interface IShifts
{
    List<Shift> GetAllShifts();
    List<Shift> GetShiftsByStatus(bool status);
    Task<Shift> UpdateShift(Shift shift);
    Task<bool> DeleteShift(string id); //Lidt usikker på hvad for en returtype en delete vil have?
    Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status);
}