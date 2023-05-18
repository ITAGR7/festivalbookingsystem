using Festivalproject.Shared.Models;
using System.Net.Http.Json;

namespace Festivalproject.Client.Services
{


    public class ShiftService : IShiftService
    {
        private readonly HttpClient Http;
        public ShiftService(HttpClient httpClient)
        {
            this.Http = httpClient;
        }



        public async Task<List<Shift>> GetAllShifts()
        {
          
            var shifts = await Http.GetFromJsonAsync<List<Shift>>("https://localhost:7251/api/shift");
            Console.WriteLine("Test getallshifts service " + shifts.ToString());
            return shifts; 
            
        }


        public async Task<Shift> CreateShift(Shift shift)
        {
           var response =  await Http.PostAsJsonAsync<Shift>("https://localhost:7251/api/shift", shift);
            if (response.IsSuccessStatusCode)
            {
                var newShift = await response.Content.ReadFromJsonAsync<Shift>();
                return newShift;
            }
            else
            {
                throw new Exception("Oprettelse af vagt fejlede.");
            }
           
        }



        public async Task<Shift> UpdateShift(Shift shiftUpdated)
        {
            Console.WriteLine(shiftUpdated.Name.ToString());

            var response = await Http.PutAsJsonAsync("https://localhost:7251/api/shift", shiftUpdated);
            if (response.IsSuccessStatusCode)
            {
                //If the httpcall is successfull, we user reafromjsonasync to fetch the newly updated shift to be returned to client
                var _shift = await response.Content.ReadFromJsonAsync<Shift>();
                return _shift; 
            }
            else
            {
                throw new Exception("Opatering af vagt fejlede");
            }
            
        }


        public Task DeleteShift(string id)
        {
            Http.DeleteAsync($"api/shifts?shiftid={id}");
            return Task.CompletedTask;
        }


    }
}
