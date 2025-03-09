
using GamesTracker.Data;
using GamesTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<ApplicationDBContext>( options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("MySqlConn"), 
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConn")))
        );
        builder.Services.AddHttpClient<ISteamService, SteamService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
