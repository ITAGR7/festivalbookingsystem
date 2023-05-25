using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivalproject.Shared.Models;
// A class used to transport data from client to database for login proces 
public class LoginDataDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
}