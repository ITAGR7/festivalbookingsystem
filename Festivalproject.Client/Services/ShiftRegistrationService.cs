using System;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Festivalproject.Client.Services;

public class ShiftRegistrationService : IShiftRegistrationService
{
    private readonly HttpClient Http;

    public ShiftRegistrationService(HttpClient httpClient)
    {
        Http = httpClient;
    }


    public async Task<List<ShiftRegistration>> GetRegisteredShiftsById(string UserId)
    {
        try
        {
            var result =
                await Http.GetFromJsonAsync<List<ShiftRegistration>>(
                    $"https://localhost:7251/api/ShiftRegistration/{UserId}");
            Console.WriteLine("Test på getregistred Service : " + result.Count);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


    public async Task CreateShiftRegistration(ShiftRegistration shiftregistration)
    {
        try
        {
            await Http.PostAsJsonAsync<ShiftRegistration>("https://localhost:7251/api/ShiftRegistration",
                shiftregistration);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}