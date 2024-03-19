
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CogeconAPI.Context;
using Microsoft.EntityFrameworkCore;
using CogeconAPI.Interfaces;
using CogeconAPI.Services;
using Newtonsoft.Json;

namespace CogeconAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<dbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICooperadoService, CooperadoService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IUnidadeConsumidoraService, UnidadeConsumidoraService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                var statusCode = context.HttpContext.Response.StatusCode;
                var message = statusCode switch
                {
                    StatusCodes.Status404NotFound => "Recurso não encontrado",
                    StatusCodes.Status503ServiceUnavailable => "O serviço está temporariamente indisponível. Por favor, tente novamente mais tarde.",
                    StatusCodes.Status200OK => "Sucesso",
                    _ => "Erro desconhecido"
                };

                response.ContentType = "application/json";

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
                    MaxDepth = 32 
                };

                await response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    status = "error",
                    message
                }, settings));
            });

            app.Run();
        }
    }
}