using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Controllers
{
    [Route("api/Shift")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        public readonly IShift ShiftRepository;


        public ShiftsController(IShift iShifts)
        {
            ShiftRepository = iShifts;
        }

        [HttpGet]
        public List<Shift> GetAllShifts()
        {
            Console.WriteLine("Get all shifts (Controller) ");

            return ShiftRepository.GetAllShifts();
        }

        [HttpGet("{status}")]
        public List<Shift> GetShiftsByStatus(bool status)
        {
            Console.WriteLine("Get shifts by status (Controller) ");

            return ShiftRepository.GetShiftsByStatus(status);
        }
    }
}
