using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services;
using Spotcheckr.Data;
using Spotcheckr.API.Mutations;
using Spotcheckr.Domain;
using AutoMapper;
using Spotcheckr.Data.Repositories;
using Spotcheckr.API.Types;
using RestSharp;
using Spotcheckr.API.Services.Validators;

namespace Spotcheckr.API
{
	public class Startup
	{
		private static IServiceCollection _services = default!;

		private static bool _sensitiveDataLoggingEnabled;

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			_sensitiveDataLoggingEnabled =
				bool.Parse(Configuration.GetSection("EntityFramework")["SensitiveDataLoggingEnabled"]);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			_services = services;

			ConfigureServices();
			ConfigureAutoMapper();
			ConfigureEntityFramework();
			ConfigureApplicationInsights();
			ConfigureGraphQL();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
				app.UseRouting()
					.UseEndpoints(endpoints => endpoints.MapGraphQL().WithOptions(new GraphQLServerOptions { Tool = { Enable = true } }))
					.UseVoyager();

		private static void ConfigureServices() => _services
			.AddTransient<IUserService, UserService>()
			.AddTransient<ICertificationService, CertificationService>()
			.AddTransient<IOrganizationService, OrganizationService>()
			.AddTransient<ICertificateService, CertificateService>()
			.AddTransient<IUnitOfWork, UnitOfWork>()
			.AddTransient<IRestClient, RestClient>()
			.AddSingleton<NASMCertificationValidator>()
			.AddSingleton<DbContext, SpotcheckrCoreContext>();

		private static void ConfigureAutoMapper() => _services.AddAutoMapper(typeof(Startup).Assembly);

		private void ConfigureEntityFramework() =>
			_services.AddDbContext<SpotcheckrCoreContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("SpotcheckrCore"))
												  .EnableSensitiveDataLogging(_sensitiveDataLoggingEnabled));

		private static void ConfigureApplicationInsights() => _services.AddApplicationInsightsTelemetry();

		private static void ConfigureGraphQL() =>
			_services.AddGraphQLServer()
					 .AddQueryType(d => d.Name("Query"))
						.AddType<UserQueries>()
						.AddType<CertificateQueries>()
					 .AddMutationType(d => d.Name("Mutation"))
						.AddType<UserMutations>()
						.AddType<CertificationMutations>()
					 .AddType<PersonalTrainerType>()
					 .AddType<AthleteType>()
					 .AddType<EmailType>()
					 .AddType<EmailInputType>()
					 .AddType<PhoneNumberType>()
					 .AddType<PhoneNumberInputType>()
					 .AddType<CertificateType>()
					 .AddType<CertificateInputType>()
					 .AddType<CertificationType>()
					 .AddType<OrganizationType>()
					 .AddEnumType<UserType>()
					 .EnableRelaySupport();
	}
}
