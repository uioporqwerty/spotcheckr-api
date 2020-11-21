using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spotcheckr.API.Data;

namespace Spotcheckr.API
{
    public class Startup
    {
	    private static IServiceCollection _services;

		public IConfiguration Configuration { get;  }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        public void ConfigureServices(IServiceCollection services)
        {
	        _services = services;
            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();

            // enable InMemory messaging services for subscription support.
            // services.AddInMemorySubscriptions();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            ConfigureEntityFramework();
			ConfigureApplicationInsights();
            ConfigureGraphQL();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
	        app
		        .UseRouting()
		        .UseWebSockets()
		        .UseGraphQL()
		        .UsePlayground()
		        .UseVoyager();

        private void ConfigureEntityFramework() => _services.AddDbContext<SpotcheckrCoreContext>(options =>
	        options.UseSqlServer(Configuration.GetConnectionString("SpotcheckrCore")));

        private static void ConfigureApplicationInsights() => _services.AddApplicationInsightsTelemetry();

		private static void ConfigureGraphQL() => _services.AddGraphQL(SchemaBuilder.New().AddQueryType<Query>());
	}
}
