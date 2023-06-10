using Microsoft.EntityFrameworkCore;
using NIPSearch.WebApi.Interfaces;
using NIPSearchApp.Data.DbContexts;
using NIPSearchApp.Data.Interfaces;
using NIPSearchApp.Data.Services;
using NIPSearchWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddScoped<IEnterpreneurService, EnterpreneurService>();

builder.Services.AddDbContext<EnterpreneurDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();