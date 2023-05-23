using System.Reflection;
using CaWorkshop.Application.Common.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(config => 
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                  .AddOpenBehavior(typeof(ValidationBehaviour<,>)));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
