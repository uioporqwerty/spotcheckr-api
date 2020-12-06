using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services.User;
using Spotcheckr.API.Types;
using Spotcheckr.API.Types.Users;
using Spotcheckr.Data;

namespace Spotcheckr.API
{
    public class Startup
    {
	    private static IServiceCollection _services = default!;

	    private static bool _sensitiveDataLoggingEnabled;

		public IConfiguration Configuration { get;  }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			_sensitiveDataLoggingEnabled =
				bool.Parse(Configuration.GetSection("EntityFramework")["SensitiveDataLoggingEnabled"]);
		}

        public void ConfigureServices(IServiceCollection services)
        {
	        _services = services;

	        _services.AddTransient<IUserService, UserService>();

            ConfigureEntityFramework();
			ConfigureApplicationInsights();
            ConfigureGraphQL();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
				app.UseRouting()
					.UseEndpoints(endpoints => endpoints.MapGraphQL())
					.UsePlayground()
					.UseVoyager();

        private void ConfigureEntityFramework() =>
	        _services.AddDbContext<SpotcheckrCoreContext>(options =>
		        options.UseSqlServer(Configuration.GetConnectionString("SpotcheckrCore"))
												  .EnableSensitiveDataLogging(_sensitiveDataLoggingEnabled));

        private static void ConfigureApplicationInsights() => _services.AddApplicationInsightsTelemetry();

		private static void ConfigureGraphQL() =>
			_services.AddGraphQLServer()
					 .EnableRelaySupport()
					 .AddQueryType(d => d.Name("Query"))
					 .AddType<UserQueries>()
					 .AddType<PersonalTrainerType>()
					 .AddType<AthleteType>();
	}
}
