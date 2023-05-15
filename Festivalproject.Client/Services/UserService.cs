﻿
using System;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;



namespace Festivalproject.Client.Services

{
    //Bruges til at kommunikere mellem klient og server, fjerner kode fra razorpage

    public class UserService : IUserService
    {
        private readonly HttpClient Http;
        public UserService(HttpClient httpClient)
        {
            this.Http = httpClient;
        }



        public async Task<User> GetUserByObjectId(string id)
        {
            try
            {
                var  result = await  Http.GetFromJsonAsync<User>($"https://localhost:7251/api/user/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        public async void CreateUser(User user)
        {
            await Http.PostAsJsonAsync<User>("https://localhost:7251/api/user", user);

        }




        public async Task UpdateUser(User userUpdated)
        {
            Console.WriteLine(userUpdated.FirstName.ToString());
            await Http.PutAsJsonAsync<User>("https://localhost:7251/api/user", userUpdated);
        }




        public Task DeleteUser(string id)
        {
            Http.DeleteAsync($"api/user?userid={id}");
            return Task.CompletedTask;
        }


    }
}