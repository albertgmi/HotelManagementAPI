using HotelManagementAPI.Entities;
using HotelManagementAPI.Seeders;
using HotelManagementAPI.Services.HotelServiceFolder;
using HotelManagementAPI.Services.ReservationServiceFolder;
using HotelManagementAPI.Services.RoomServiceFolder;
using HotelManagementAPI.Services.UserServiceFolder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
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
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Scope for seeder

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
var seeder = scope.ServiceProvider.GetService<IHotelSeeder>();
seeder.Seed(dbContext);

app.Run();
