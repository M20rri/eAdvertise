using eAdvertise.Application;
using eAdvertise.Infrastructure.Persistence;
using eAdvertise.Infrastructure.Persistence.Contexts;
using eAdvertise.Infrastructure.Shared;
using eAdvertise.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // load up serilog configuraton
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
    builder.Host.UseSerilog(Log.Logger);
    builder.Services.AddApplicationLayer();
    builder.Services.AddPersistenceInfrastructure(builder.Configuration);
    builder.Services.AddSharedInfrastructure(builder.Configuration);
    builder.Services.AddResourceLocalization();
    builder.Services.AddSwaggerExtension();
    builder.Services.AddControllersExtension();

    // CORS
    builder.Services.AddCorsExtension();
    //API Security
    builder.Services.AddJWTAuthentication(builder.Configuration);
    builder.Services.AddHealthChecks();
    // API version
    builder.Services.AddApiVersioningExtension();
    // API explorer
    builder.Services.AddMvcCore()
        .AddApiExplorer();
    // API explorer version
    builder.Services.AddVersionedApiExplorerExtension();
    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        // use context
        dbContext.Database.EnsureCreated();
    }


    // Add this line; you'll need `using Serilog;` up the top, too
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseStaticFilesExtension();
    app.UserResourceLocalization();

    //Enable CORS
    app.UseCors("AllowAll");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwaggerExtension();
    app.UseErrorHandlingMiddleware();
    app.MapControllers();
    app.Run();

    Log.Information("Application Starting");

}
catch (Exception ex)
{
    Log.Warning(ex, "An error occurred starting the application");
}
finally
{
    Log.CloseAndFlush();
}
