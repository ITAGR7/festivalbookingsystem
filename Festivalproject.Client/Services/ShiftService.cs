using Festivalproject.Shared.Models;
using System.Net.Http.Json;

namespace Festivalproject.Client.Services;

public class ShiftService : IShiftService
{
    private readonly HttpClient Http;

    public ShiftService(HttpClient httpClient)
    {
        Http = httpClient;
    }


    public async Task<List<Shift>> GetAllShifts()
    {
        try
        {
            var shifts = await Http.GetFromJsonAsync<List<Shift>>("/api/shift");
            Console.WriteLine("Test getallshifts service " + shifts.ToString());
            return shifts;
        }
        catch (Exception ex) { 

            Console.WriteLine("An error occurred while getting all shifts: " + ex.Message);
            throw;
        }
    }



    public async Task<Shift> CreateShift(Shift shift)
    {
        try
        {
            var response = await Http.PostAsJsonAsync("/api/shift", shift);
            response.EnsureSuccessStatusCode();
            var newShift = await response.Content.ReadFromJsonAsync<Shift>();
            return newShift;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating a shift: " + ex.Message);
            return null; 
            
        }
    }



    public async Task<Shift> UpdateShift(Shift shiftUpdated)
    {
        try
        {
            var response = await Http.PutAsJsonAsync("/api/shift", shiftUpdated);
            response.EnsureSuccessStatusCode();
            var _shift = await response.Content.ReadFromJsonAsync<Shift>();
            return _shift;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while updating a shift: " + ex.Message);
            throw; 
        }
    }

    public async Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status)
    {
        try
        {
            var response = await Http.PutAsJsonAsync($"/api/shift/update/{Id}/{Status}", Id);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Updating of shift failed");

            return true;
        }
        catch (Exception ex)
        {

            Console.WriteLine("An error occurred while updating shift status: " + ex.Message);
            throw; 
        }
    }


    public async Task<bool> DeleteShift(string id)
    {
        try
        {
            var response = await Http.DeleteAsync($"/api/shift/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error, throw a custom exception, etc.)
            Console.WriteLine("An error occurred while deleting a shift: " + ex.Message);
            throw; // Rethrow the exception or throw a custom exception
        }
    }


    public async Task<List<Shift>> GetShiftsByStatus(bool Status)
    {
        try
        {
            var result = await Http.GetFromJsonAsync<List<Shift>>("/api/shift/status/" + Status);
            return result;
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error, throw a custom exception, etc.)
            Console.WriteLine("An error occurred while getting shifts by status: " + ex.Message);
            throw; // Rethrow the exception or throw a custom exception
        }
    }



}