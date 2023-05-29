using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Festivalproject.Client.Services;

public class LoginService : ILoginService
{
    private readonly HttpClient Http;

    public LoginService(HttpClient httpClient)
    {
        Http = httpClient;
    }

    //Method that uses a HttpPost to pass the loginData object to the database. By using a post, versus using a get, we make sure sensitive data is not passed 
    //...uneccesseraly from database to client 
    public async Task<LoginResultDTO> GetLoginResult(LoginDataDTO loginData)
    {
        try
        {
            var response = await Http.PostAsJsonAsync("/api/user/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResultDTO>();
                return loginResult;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here or log it
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        throw new Exception("Login fejlet. Brugernavn og/eller kodeord findes ikke.");
    }
}