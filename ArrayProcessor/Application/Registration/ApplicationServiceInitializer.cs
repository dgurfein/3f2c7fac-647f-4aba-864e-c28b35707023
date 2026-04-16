using Application.Registrations;
using ArrayProcessor.Application.DTOs;
using ArrayProcessor.Application.Interfaces;
using ArrayProcessor.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace ArrayProcessor.Application.Registration
{
    public static class ApplicationServiceInitializer
    {
        // Registers all services for the MissingNumber use case
        public static void ServicesRegistration(this IServiceCollection services)
        {
            // use cases 
            // Longest Increasing Sequence - registering all as singleton as it runs from command line once.
            services.AddSingleton<IParser<LongestIncreasingSequenceRequest>, NumberChainParser>();
            services.AddSingleton<IValidator<LongestIncreasingSequenceRequest>, NumberChainValidator>();
            services.AddSingleton<IProcessor<LongestIncreasingSequenceRequest, LongestIncreasingSequenceResult>, NumberChainProcessor>();
            services.AddSingleton<IUseCase, LongestIncreasingSequenceUseCase>();

            // register the resolver
            services.AddSingleton<IUseCaseResolver, UseCaseResolver>();
        }
    }
}
