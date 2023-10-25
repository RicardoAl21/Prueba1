using BackApi.Models;
using Microsoft.EntityFrameworkCore;
using BackApi.Services.Contracts;
using BackApi.Services.Implementation;
using AutoMapper;
using BackApi.DTO;
using BackApi.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PruebaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("New Politics", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("New Politics");

app.Run();
