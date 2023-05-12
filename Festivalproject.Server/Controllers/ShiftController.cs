using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;

namespace Festivalproject.Server.Controllers
{
    [Route("api/Shifts")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        public readonly IShifts ShiftRepository;


        public ShiftsController(IShifts iShifts)
        {
            ShiftRepository = iShifts;
        }

        [HttpGet]
        public List<Shifts> GetAllShifts()
        {
            Console.WriteLine("Get all shifts (Controller) ");

            return ShiftRepository.GetAllShifts();
        }

        [HttpGet("{status}")]
        public List<Shifts> GetShiftsByStatus(bool status)
        {
            Console.WriteLine("Get shifts by status (Controller) ");

            return ShiftRepository.GetShiftsByStatus(status);
        }
    }
}
