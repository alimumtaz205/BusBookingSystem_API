using BusBookingSystem.Repositories;
using BusBookingSystem.Repositories.BusesRepository;
using BusBookingSystem.Repositories.ReservationRepository;
using BusBookingSystem.Repositories.RouteRepository;
using BusBookingSystem.Repositories.ScheduleRepository;
using BusBookingSystem.Repositories.UserManagementRepository;
using BusBookingSystem.Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBus_Repository, Bus_Repository>();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IUserMgtRepository, UserMgtRepository>();
builder.Services.AddSingleton<IRouteRepository, RouteRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
