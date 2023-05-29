using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;
using MongoDB.Driver;

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


    // HTTP GET all users in the user collection.
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
        try
        {
            var user = UserRepository.GetUserByObjectId(id);
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Der opstod en fejl under hentning af brugeren: {ex.Message}");
            return null; // Eller kast en egendefineret undtagelse, hvis nødvendigt
        }
    }

    // Method that posts a a loginresult taking a LoginData object as parameter
    // Using a extension to our endpoint, to distinguish this from other HttpPost calls in the controller. 
    [HttpPost("login")]
    public ActionResult<LoginResultDTO> GetLoginResult([FromBody] LoginDataDTO loginData)
    {
        try
        {
            var result = UserRepository.GetLoginResult(loginData.Username, loginData.Password);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Brugernavn eller adgangskode er ugyldig.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    // HTTP post to create a new user, and inset it in collection. 
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
    //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<UpdateResult> UpdateUser(User userUpdated)
    {
        try
        {
            var result = await UserRepository.UpdateUser(userUpdated);
            return result;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Der opstod en fejl under opdatering af brugeren: {ex.Message}");
            return null; 
        }
    }


    
}