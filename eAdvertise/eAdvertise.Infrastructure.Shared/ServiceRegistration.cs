﻿using eAdvertise.Application.Interfaces;
using eAdvertise.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAdvertise.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}