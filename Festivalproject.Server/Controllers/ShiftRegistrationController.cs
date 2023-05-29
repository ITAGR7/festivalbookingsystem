using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Repository;
using static System.Net.WebRequestMethods;

namespace Festivalproject.Server.Controllers;

[Route("api/ShiftRegistration")]
[ApiController]
public class ShiftRegistrationController : ControllerBase
{
    public readonly IShiftRegistration ShiftRegistrationRepo;


   // Initializes the ShiftRegistrationRepo to be a copy of iShiftRegistrationRepo
    public ShiftRegistrationController(IShiftRegistration iShiftRegistrationRepo)
    {
        ShiftRegistrationRepo = iShiftRegistrationRepo;
    }


    // HTTP GET method to retrieve registered shifts by user ID, and returns a list of ShiftRegistration objects.
    [HttpGet("{UserId}")]
    public List<ShiftRegistration> GetRegisteredShiftsById(string UserId)
    {
        var result = ShiftRegistrationRepo.GetRegisteredShiftsById(UserId);
        Console.WriteLine("Controller: Get shifts : Antal shifts fundet " + result.Count());
        return result;
    }

    //HTTP PUT method to update a shift registration by shift ID.
    [HttpPut]
    public Task<bool> UpdateShiftRegistrationbyShiftId(Shift _shift)
    {
        var result = ShiftRegistrationRepo.UpdateShiftRegistrationByShiftId(_shift);
        return result;
    }


    //HTTP POST method to create a new shift registration.
    [HttpPost]
    public async Task<IActionResult> CreateShiftRegistration(ShiftRegistration shiftregistration)
    {
        var result = ShiftRegistrationRepo.CreateShiftRegistration(shiftregistration);
        if (result != null)
            return Ok();
        else
            return StatusCode(500, "Internal server error. Update failed.");
    }

}