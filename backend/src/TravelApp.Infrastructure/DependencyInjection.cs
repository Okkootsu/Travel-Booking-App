using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Infrastructure.Persistence;
using TravelApp.Infrastructure.Persistence.Repositories;

namespace TravelApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Sözleşmelerin somut sınıflarla eşleştirilmesi
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Güvenlik servisleri
            services.AddSingleton<IPasswordHasher, Services.PasswordHasher>();
            services.AddSingleton<IJwtTokenGenerator, Services.JwtTokenGenerator>();

            return services;
        }
    }
}