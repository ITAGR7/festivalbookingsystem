using Festivalproject.Server.Repository;
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

        [HttpGet("login")]

        public bool IsValidLogin(string username, string password)
        {
            Console.WriteLine("IsvalidLogin");
            var user = UserRepository.IsValidLogin(username, password);
            if (user != true)
            {
                return false;
            }
            else { return true; }

        }


        [HttpPost]
        public string CreateUser(User user)
        {
            //Test of CreateUser on Controller
            UserRepository.CreateUser(user);
            return user.UserName;
        }



        //[HttpPut]
        //public void PutUser(User user)
        //{
        //    Repository.PutUser(user);
        //}

        //[HttpDelete]
        //public void DeleteUser(int userid)
        //{
        //    Repository.DeleteUser(userid);
        //}
    }
}

