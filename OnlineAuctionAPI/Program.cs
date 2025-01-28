using OnlineAuctionAPI;
using OnlineAuctionAPI.Controllers;
using AutoMapper;
using DB;
using OnlineAuctionAPI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<MongoDbService>();
var app = builder.Build();

//DBConnection.Configure();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//AddDummyData.AddDummyProduct();
//AddDummyData.AddDummyUser();
//AddDummyData.AddDummyAdmin();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapUserEndpoints();

app.MapProductEndpoints();

app.Run();
