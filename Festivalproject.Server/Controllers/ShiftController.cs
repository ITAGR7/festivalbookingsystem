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

    [HttpPut("update/{Id}/{Status}")]
    public async Task<IActionResult> UpdateShiftStatusByShiftId(string Id, bool Status)
    {
        var result = await ShiftRepository.UpdateShiftStatusByShiftId(Id, Status);
        if (result != null)
            return Ok();
        else
            return StatusCode(500, "Internal server error. Update failed.");
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