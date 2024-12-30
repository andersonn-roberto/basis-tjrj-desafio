using LivrosApp.Application;
using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Infra.Context;
using LivrosApp.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LivrosApp.Api
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            QuestPDF.Settings.License = LicenseType.Community;

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string" + "'DefaultConnection' not found.");
            builder.Services.AddDbContext<LivrosAppContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            builder.Services.AddScoped<IAutorRepository, AutorRepository>();
            builder.Services.AddScoped<ICanalVendaRepository, CanalVendaRepository>();
            builder.Services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();
            builder.Services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
            builder.Services.AddScoped<ILivroRepository, LivroRepository>();
            builder.Services.AddScoped<ITabelaPrecoRepository, TabelaPrecoRepository>();

            builder.Services.AddScoped<IAssuntoService, AssuntoService>();
            builder.Services.AddScoped<IAutorService, AutorService>();
            builder.Services.AddScoped<ICanalVendaService, CanalVendaService>();
            builder.Services.AddScoped<ILivroService, LivroService>();

            builder.Services.AddScoped<IPdfService, PdfService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}