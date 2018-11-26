using System;
using Microsoft.Extensions.DependencyInjection;

namespace hackathonvoice.Domain
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
        
    }
}