using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;


namespace Festivalproject.Server.Controllers;

// Modtager HttpRequests fra services, sender requests til repositories og returnerer resultatet
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser UserRepository;

    public UserController(IUser repo)
    {
        UserRepository = repo;
    }


    [HttpGet]
    public List<User> GetAllUsers()
    {
        return UserRepository.GetAllUsers().ToList();
    }


    //Using a parameter in the endpoint, which allows for an ID to be passed from client via url, to this endpoint. 
    //the uri /api/user/123 would then set the id here to 123. 
    [HttpGet("{id}")]
    public User GetUserByObjectId(string id)
    {
        var user = UserRepository.GetUserByObjectId(id);
        return user;
    }


    // Using a extension to our endpoint, to distinguish this from other HttpPost calls in the controller. 
    //
    [HttpPost("login")]
    public LoginResultDTO GetLoginResult([FromBody] LoginDataDTO loginData)
    {
        Console.WriteLine(loginData.Username);
        Console.WriteLine("login");
        var result = UserRepository.GetLoginResult(loginData.Username, loginData.Password);
        return result;
    }


    [HttpPost]
    public IActionResult CreateUser(User newUser)
    {
        try
        {
            var createdUser = UserRepository.CreateUser(newUser);
            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPut]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult UpdateUser(User userUpdated)
    {
        UserRepository.UpdateUser(userUpdated);
        return NoContent();
    }


    
}