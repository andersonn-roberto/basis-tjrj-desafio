using LivrosApp.Application;
using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Infra.Context;
using LivrosApp.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LivrosApp.Api
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string" + "'DefaultConnection' not found.");
            builder.Services.AddDbContext<LivrosAppContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ILivroRepository, LivroRepository>();
            builder.Services.AddScoped<IAutorRepository, AutorRepository>();

            builder.Services.AddScoped<ILivroService, LivroService>();
            builder.Services.AddScoped<IAutorService, AutorService>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            await app.RunAsync();
        }
    }
}