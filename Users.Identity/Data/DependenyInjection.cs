using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.Identity.Models;

namespace Users.Identity.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration){
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AuthDbContext>(options =>{
                options.UseNpgsql(connectionString);
            });
            services.AddIdentity<AppUser, IdentityRole>(config => {
                config.Password.RequiredLength = 8;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;


            })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            
            
            return services;
        }
    }
}