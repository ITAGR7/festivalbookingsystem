
using System;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;


namespace Festivalproject.Client.Services

{
    //Bruges til at kommunikere mellem klient og server

    public class UserService : IUserService
    {
        private readonly HttpClient Http;
        public UserService(HttpClient httpClient)
        {
            this.Http = httpClient;
        }



        public Task<User> GetUser(int userid)
        {
            var result = Http.GetFromJsonAsync<User>($"api/user?userid={userid}");
            return result;
        }

        public async void CreateUser(User user)
        {
            await Http.PostAsJsonAsync<User>("api/user", user);
        }

        public async Task UpdateUser(User user)
        {
            await Http.PutAsJsonAsync<User>("api/user", user);
        }
        public Task DeleteUser(int userid)
        {
            Http.DeleteAsync($"api/user?userid={userid}");
            return Task.CompletedTask;
        }


        public async Task<bool> IsValidLogin(string username, string password)
        {
            var url = $"https://localhost:7251/api/user/login?username={username}&password={password}";
            var result = await Http.GetFromJsonAsync<bool>(url);

            if (result == true)
            {
                Console.WriteLine("Bruger fundet i databasen");
                return true;
            }

            Console.WriteLine("Bruger ikke fundet, eller forkert password");
            return false;
        }

    }
}