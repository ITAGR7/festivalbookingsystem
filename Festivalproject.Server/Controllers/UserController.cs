
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Festivalproject.Server.Interface;



namespace Festivalproject.Server.Controllers
{
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


        //Her anvender vi et parameter ifm. logind
        [HttpGet("{id}")]
        public User GetUserByObjectId(string id)
        {

            User user =  UserRepository.GetUserByObjectId(id);
            return user; 
        }


        [HttpPost("login")]
        public LoginResult GetLoginResult([FromBody] LoginData loginData)
        {
            Console.WriteLine(loginData.username);
            Console.WriteLine("login");
                var result = UserRepository.GetLoginResult(loginData.username,loginData.password);
                return result;
        }


        //Denne kunne laves om til en klasse  for sig selv 
        public class LoginData
        {
            public string username { get; set; }
            public string password { get; set; }
        }




        [HttpPost]
        public string CreateUser(User user)
        {
            //Test of CreateUser on Controller
            UserRepository.CreateUser(user);
            return user.Id; 
        }





        //[HttpPut]
        //public void UpdateUser(User userUpdated)
        //{
        //    UserRepository.UpdateUser(userUpdated);
        //}

        [HttpPut]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult UpdateUser(User userUpdated)
        {
            UserRepository.UpdateUser(userUpdated);
            return NoContent();
        }





        //[HttpDelete]
        //public void DeleteUser(int userid)
        //{
        //    Repository.DeleteUser(userid);
        //}
    }
}

