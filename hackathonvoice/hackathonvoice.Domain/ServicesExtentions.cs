using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace hackathonvoice.Domain
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IParserService, ParserService>();
            services.AddScoped<ISpeechService, YandexSpeechService>();
            
            return services;
        }
        
    }
}