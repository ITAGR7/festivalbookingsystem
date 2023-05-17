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



        public async Task<List<Shift>> GetAllShifts()
        {
            return await Http.GetFromJsonAsync<List<Shift>>("https://localhost:7251/api/shift");
        }

        public async void CreateShift(Shift newShift)
            {
                await Http.PostAsJsonAsync<Shift>("https://localhost:7251/api/shift", newShift);

            }




            public async Task UpdateShift(Shift shiftUpdate)
            {
                Console.WriteLine(shiftUpdate.Name.ToString());
                await Http.PutAsJsonAsync<Shift>("https://localhost:7251/api/shift", shiftUpdate);
            }




            public Task DeleteShift(string id)
            {
                Http.DeleteAsync($"api/shifts?shiftid={id}");
                return Task.CompletedTask;
            }


    
    }
    }
