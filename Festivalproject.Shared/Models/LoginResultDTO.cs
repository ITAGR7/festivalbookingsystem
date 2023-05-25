using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivalproject.Shared.Models;
// A class user for transporting data on the user in the login proces 
public class LoginResultDTO
{
    public bool IsValid { get; set; }

    public string UserType { get; set; }

    public string ObjectId { get; set; }
}