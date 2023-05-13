using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Festivalproject.Client.Services
{
    public class LoginService : ILoginService
    {

        private readonly HttpClient Http;
        public LoginService(HttpClient httpClient)
        {
            this.Http = httpClient;
        }

        public async Task<LoginResult> GetLoginResult(string username, string password)
        {
           
            var requestBody = new { username, password }; //Når man sender som requestbody, vises ikke parametrene i url 

            var response = await Http.PostAsJsonAsync($"https://localhost:7251/api/user/login", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();

                return loginResult;
            }

            throw new Exception("Login lykkes ikke ");


        }
    }
}

