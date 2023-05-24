﻿using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Repository;

namespace Festivalproject.Server.Controllers;

[Route("api/ShiftRegistration")]
[ApiController]
public class ShiftRegistrationController : ControllerBase
{
    public readonly IShiftRegistration ShiftRegistrationRepo;

    public ShiftRegistrationController(IShiftRegistration iShiftRegistrationRepo)
    {
        ShiftRegistrationRepo = iShiftRegistrationRepo;
    }


    [HttpGet("{UserId}")]
    public List<ShiftRegistration> GetRegisteredShiftsById(string UserId)
    {
        var result = ShiftRegistrationRepo.GetRegisteredShiftsById(UserId);
        Console.WriteLine("Controller: Get shifts : Antal shifts fundet " + result.Count());
        return result;
    }


    [HttpPut]
    public Task<bool> UpdateShiftRegistrationbyShiftId(Shift _shift)
    {
        var result = ShiftRegistrationRepo.UpdateShiftRegistrationByShiftId(_shift);
        return result;
    }

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