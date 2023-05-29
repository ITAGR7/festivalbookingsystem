using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Festivalproject.Server.Controllers;

[Route("api/shift")]
[ApiController]
public class ShiftsController : ControllerBase
{
    public readonly IShifts ShiftRepository;


    // itializes the ShiftRepository to be a copy of iShifts.
    public ShiftsController(IShifts iShifts)
    {
        ShiftRepository = iShifts;
    }


    //HTTP GET method to retrieve all shifts from the Shift collection.
    [HttpGet]
    public List<Shift> GetAllShifts()
    {
        Console.WriteLine("Get all shifts (Controller) ");

        return ShiftRepository.GetAllShifts();
    }



    // HTTP GET method to retrieve shifts by their status from the Shift collection.
    [HttpGet("status/{status}")]
    public List<Shift> GetShiftsByStatus(bool status)
    {
        Console.WriteLine("Get shifts by status (Controller) ");

        return ShiftRepository.GetShiftsByStatus(status);
    }



    // HTTP PUT method to update shifts.
    [HttpPut]
    public async Task<Shift> UpdateShift(Shift shiftUpdated)
    {
        Console.WriteLine("Updateshift test, controller" + shiftUpdated.Id);
        return await ShiftRepository.UpdateShift(shiftUpdated);
    }

    //HTTP PUT method to update the status of a shift by its ID.
    [HttpPut("update/{Id}/{Status}")]
    public async Task<IActionResult> UpdateShiftStatusByShiftId(string Id, bool Status)
    {
        var result = await ShiftRepository.UpdateShiftStatusByShiftId(Id, Status);
        if (result != null)
            return Ok();
        else
            return StatusCode(500, "Internal server error. Update failed.");
    }


    // HTTP DELETE method to delete a shift by its ID.
    [HttpDelete("{id}")]
    public async Task<bool> DeleteShift(string id)
    {
        var result = await ShiftRepository.DeleteShift(id);
        return result;
    }


    //HTTP POST method to create a new shift.
    [HttpPost]
    public async Task<Shift> CreateShift(Shift newShift)
    {
        Console.WriteLine("CreateShift på controller");
        var result = await ShiftRepository.CreateShift(newShift);
        return result;
    }
}