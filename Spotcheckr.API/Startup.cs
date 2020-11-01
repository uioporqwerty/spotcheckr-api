using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;

namespace Spotcheckr.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();

            // enable InMemory messaging services for subscription support.
            // services.AddInMemorySubscriptions();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

			ConfigureApplicationInsights(services);

            ConfigureGraphQL(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
	        app
		        .UseRouting()
		        .UseWebSockets()
		        .UseGraphQL()
		        .UsePlayground()
		        .UseVoyager();

        private static void ConfigureApplicationInsights(IServiceCollection services) =>
	        services.AddApplicationInsightsTelemetry();

		private static void ConfigureGraphQL(IServiceCollection services) => services.AddGraphQL(SchemaBuilder.New().AddQueryType<Query>());
	}
}
