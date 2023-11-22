using eAdvertise.Application.Interfaces;
using eAdvertise.Application.Interfaces.Repositories;
using eAdvertise.Domain.Entities;
using eAdvertise.Infrastructure.Persistence.Contexts;
using eAdvertise.Infrastructure.Persistence.Repositories;
using eAdvertise.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAdvertise.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("AdvConstr"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IAdvertiseRepositoryAsync, AdvertiseRepositoryAsync>();
            services.AddTransient<ICarRepositoryAsync, CarRepositoryAsync>();
            services.AddTransient<IMobileRepositoryAsync, MobileRepositoryAsync>();
            services.AddTransient<IMiscRepositoryAsync, MiscRepositoryAsync>();
            #endregion Repositories
        }
    }
}