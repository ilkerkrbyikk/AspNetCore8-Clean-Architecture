using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        //VALIDATION REGISTIRATION
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
            .AddFluentValidationAutoValidation();
    }
}
