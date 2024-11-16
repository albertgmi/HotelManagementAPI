using HotelManagementAPI.Entities;
using HotelManagementAPI.Seeders;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework stuff

builder.Services.AddDbContext<HotelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelsConnectionString"));
});
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddScoped<IHotelSeeder, HotelSeeder>();

// API stuff

builder.Services.AddControllers();



var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
