using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using RetailApp.Api.MiddleWare;
using RetailApp.Application;
using RetailApp.Application.Commands;
using RetailApp.Application.Commands.AuthenticateUserCommand;
using RetailApp.Application.Commands.Bill;
using RetailApp.Application.Models;
using RetailApp.Application.Service;
using RetailApp.Domain.Common;
using RetailApp.Infrastructure.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR(typeof(Initializer).Assembly);

var assemblies = new Assembly[]
    {
        typeof(Program).Assembly,
        typeof(Initializer).Assembly,
    };

builder.Services.AddAutoMapper(assemblies);
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

//builder.Services.AddScoped<IRequestHandler<BillDiscountCommand, BillDto>, BillDiscountCommandHandler>();
builder.Services.AddScoped<IBillDiscountService, BillDiscountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//builder.Services.AddScoped<IRequestHandler<AuthenticateUserCommand, AuthenticationUser>, AuthenticateUserCommandHandler>();
//



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();
