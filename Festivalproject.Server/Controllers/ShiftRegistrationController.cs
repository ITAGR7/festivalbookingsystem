using Microsoft.AspNetCore.Mvc;
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
        

                




        //    public List<ShiftRegistration> GetRegisteredShiftsById(string UserID) {

    //        Console.WriteLine("Get all shifts (Controller) ");

    //        return ShiftRegistrationRepo.GetRegisteredShiftsById();
    //    }
    //}

    //create shiftregistrationbyshiftid and userid
    [HttpPost]
    public void CreateShiftRegistration(ShiftRegistration shiftregistration)
    {
        ShiftRegistrationRepo.CreateShiftRegistration(shiftregistration);
    }
}