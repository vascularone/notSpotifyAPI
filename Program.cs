using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using NotSpotifyAPI.Infrastructure.Persistence;
using Application.DI;
using Application.Common.Interfaces.Repositories;
using NotSpotifyAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
mySqlConnectionStringBuilder.Password = "root";
builder.Services.AddDbContext<ApplicationDbContext>(options =>

options.UseMySql(
                  mySqlConnectionStringBuilder.ConnectionString,
                  ServerVersion.AutoDetect(mySqlConnectionStringBuilder.ConnectionString)), ServiceLifetime.Scoped);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.ConfigureServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
