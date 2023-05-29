using System;
using System.Net;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;


namespace Festivalproject.Client.Services;
//Service is used for Http calls to the controller, removes this code from razorpage 

public class UserService : IUserService
{
    private readonly HttpClient Http;

    public UserService(HttpClient httpClient)
    {
        Http = httpClient;
    }


    public async Task<User> GetUserByObjectId(string id)
    {
        try
        {
            var result = await Http.GetFromJsonAsync<User>($"/api/user/{id}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


    public async Task<User> CreateUser(User user)
    {
        var response = await Http.PostAsJsonAsync<User>("/api/user", user);


        if (response.IsSuccessStatusCode)
        {
            var newUser = await response.Content.ReadFromJsonAsync<User>();
            return newUser;
        }
        else if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }

        throw new Exception(response.StatusCode.ToString());
    }


    public async Task UpdateUser(User userUpdated)
    {
        Console.WriteLine(userUpdated.FirstName.ToString());
        await Http.PutAsJsonAsync("/api/user", userUpdated);
    }


    public Task DeleteUser(string id)
    {
        Http.DeleteAsync($"api/user?userid={id}");
        return Task.CompletedTask;
    }
}