using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Controllers;

[Route("api/shift")]
[ApiController]
public class ShiftsController : ControllerBase
{
    public readonly IShifts ShiftRepository;

    public ShiftsController(IShifts iShifts)
    {
        ShiftRepository = iShifts;
    }

    [HttpGet]
    public List<Shift> GetAllShifts()
    {
        Console.WriteLine("Get all shifts (Controller) ");

        return ShiftRepository.GetAllShifts();
    }
    
    [HttpGet("id/{id}")]
    public Shift GetShiftById(string id)
    {
        Console.WriteLine("Get shift by id (Controller) ");

        return ShiftRepository.GetShiftById(id);
    }

    [HttpGet("status/{status}")]
    public List<Shift> GetShiftsByStatus(bool status)
    {
        Console.WriteLine("Get shifts by status (Controller) ");

        return ShiftRepository.GetShiftsByStatus(status);
    }

    [HttpPut]
    public async Task<Shift> UpdateShift(Shift shiftUpdated)
    {
        Console.WriteLine("Updateshift test, controller" + shiftUpdated.Id);
        return await ShiftRepository.UpdateShift(shiftUpdated);

    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteShift(string id)
    {
        var result = await ShiftRepository.DeleteShift(id);
        return result;
    }


    //[HttpPost]
    //public async Task<Shift> CreateShift(Shift newShift)
    //{
    //    var result = await ShiftRepository.CreateShift(newShift);
    //    return result;
    //}
}