using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Repository;

namespace Festivalproject.Server.Controllers

{
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
            List<ShiftRegistration> shiftregistration = ShiftRegistrationRepo.GetRegisteredShiftsById(UserId);
            return shiftregistration;
        }


        //    public List<ShiftRegistration> GetRegisteredShiftsById(string UserID) {

        //        Console.WriteLine("Get all shifts (Controller) ");

        //        return ShiftRegistrationRepo.GetRegisteredShiftsById();
        //    }
        //}
    }
}