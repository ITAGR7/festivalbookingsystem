using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Festivalproject.Client.Services;
using Festivalproject.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<ILoginService, LoginService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IShiftRegistrationService, ShiftRegistrationService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IShiftService, ShiftService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});


builder.Services
    .AddBlazoredModal(); // tiløjede denne linje for at den kan bruges i program.cs fra dummyShifts og Shifts

await builder.Build().RunAsync();