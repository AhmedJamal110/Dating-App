using App.API.DataContext;
using App.API.Helper;
using App.API.Interfaces;
using App.API.Repositories;
using App.API.Services;
using Microsoft.EntityFrameworkCore;

namespace App.API.Extension
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration config)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.AddDbContext<DataDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefalutConnection"));
            });

            services.AddScoped<IUserRepositaory, UserRepo>();
            services.AddAutoMapper(typeof(MappingProfile));
             services.AddCors();


            return services;
        } 


    }
}
