using App.API.DataContext;
using App.API.Extension;
using App.API.Interfaces;
using App.API.MiddelWare;
using App.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddelware>();
            using var Scope = app.Services.CreateScope();
            var servicesProvid =Scope.ServiceProvider;
            var loggerFact = servicesProvid.GetRequiredService<ILoggerFactory>(); 
            try
            {
                var dbContext = servicesProvid.GetRequiredService<DataDbContext>();
                await  dbContext.Database.MigrateAsync();

               await  DbContextSeeding.DatabseSeedingData(dbContext, loggerFact);
            }
            catch (Exception ex)
            {
               var logger = loggerFact.CreateLogger<Program>();
                logger.LogError(ex.Message, "Error while migrations ");
            }


            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
