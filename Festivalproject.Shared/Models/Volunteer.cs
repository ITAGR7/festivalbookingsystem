using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivalproject.Shared.Models;

internal class Volunteer : User
{
    public Volunteer()
    {
    }

    public string VolunteerId { get; set; }
}