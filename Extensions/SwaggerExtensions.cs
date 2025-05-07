using Microsoft.OpenApi.Models;

namespace DavidOsicka30.CSharp.WebApiTemplate.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Web API template",
                Version = "v1",
                Description = "TODO: change description",
                Contact = new OpenApiContact
                {
                    Name = "Contact us",
                    Url = new Uri("https://todo.contact.us.com/"),
                },
                License = new OpenApiLicense
                {
                    Name = "Licence: Buy Me a Coffee",
                    Url = new Uri("https://buymeacoffee.com/davidosicka"),
                }
            });
            // enable swagger attributes 
            options.EnableAnnotations();
        });

        return services;
    }
    
    public static WebApplication UseSwaggerForDevelopment(this WebApplication application)
    {
        if (!application.Environment.IsDevelopment()) return application;
        
        application.UseSwagger();
        application.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
        });

        return application;
    }
}