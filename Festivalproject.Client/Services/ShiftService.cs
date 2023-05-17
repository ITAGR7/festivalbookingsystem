using System;
using System.Net.Http.Json;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;



namespace Festivalproject.Client.Services

    {
        //Bruges til at kommunikere mellem klient og server, fjerner kode fra razorpage

        public class ShiftService : IShiftService
        {
            private readonly HttpClient Http;
            public ShiftService(HttpClient httpClient)
            {
                this.Http = httpClient;
            }



        public async Task<List<Shifts>> GetAllShifts()
        {
            return await Http.GetFromJsonAsync<List<Shifts>>("https://localhost:7251/api/shift");
        }

        public async void CreateShift(Shifts shift)
            {
                await Http.PostAsJsonAsync<Shifts>("https://localhost:7251/api/shift", shift);

            }




            public async Task UpdateShift(Shifts shiftUpdate)
            {
                Console.WriteLine(shiftUpdate.Name.ToString());
                await Http.PutAsJsonAsync<Shifts>("https://localhost:7251/api/shift", shiftUpdate);
            }




            public Task DeleteShift(string id)
            {
                Http.DeleteAsync($"api/shifts?shiftid={id}");
                return Task.CompletedTask;
            }


    
    }
    }
