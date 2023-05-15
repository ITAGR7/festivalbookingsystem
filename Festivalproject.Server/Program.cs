using Festivalproject.Server.Interface;
using Festivalproject.Server.Repository;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        corsPolicyBuilder => corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IShifts, ShiftRepository>();
//Adding a service implementing iuser, and userrepository 
builder.Services.AddSingleton<IUser, UserRepository>();
builder.Services.AddSingleton<IShiftRegistration, ShiftRegistrationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();