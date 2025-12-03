using ApiUser.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();

app.MapControllers();

app.Run();