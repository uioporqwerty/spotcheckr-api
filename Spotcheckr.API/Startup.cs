using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services;
using Spotcheckr.API.Data;
using Spotcheckr.API.Mutations;
using Spotcheckr.API.Models;
using AutoMapper;
using Spotcheckr.API.Data.Repositories;
using Spotcheckr.API.Types;
using RestSharp;
using Spotcheckr.API.Services.Validators;
using HotChocolate.Execution.Options;

namespace Spotcheckr.API
{
	public class Startup
	{
		private static IServiceCollection _services = default!;

		private static bool _sensitiveDataLoggingEnabled;

		private static bool _apolloTracingEnabled;

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			_sensitiveDataLoggingEnabled =
				bool.Parse(Configuration.GetSection("EntityFramework")["SensitiveDataLoggingEnabled"]);
			_apolloTracingEnabled =
				bool.Parse(Configuration.GetSection("GraphQL")["ApolloTracingEnabled"]);

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
			.AddScoped<IUserService, UserService>()
			.AddScoped<ICertificationService, CertificationService>()
			.AddScoped<IOrganizationService, OrganizationService>()
			.AddScoped<ICertificateService, CertificateService>()
			.AddScoped<IExercisePostService, ExercisePostService>()
			.AddScoped<IUnitOfWork, UnitOfWork>()
			.AddScoped<IUserRepository, UserRepository>()
			.AddScoped<IExercisePostRepository, ExercisePostRepository>()
			.AddScoped<IEmailRepository, EmailRepository>()
			.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>()
			.AddScoped<ICertificationRepository, CertificationRepository>()
			.AddScoped<ICertificateRepository, CertificateRepository>()
			.AddScoped<IOrganizationRepository, OrganizationRepository>()
			.AddTransient<IRestClient, RestClient>()
			.AddSingleton<NASMCertificationValidator>();

		private static void ConfigureAutoMapper() => _services.AddAutoMapper(typeof(Startup).Assembly);

		private void ConfigureEntityFramework() =>
			_services.AddDbContext<SpotcheckrCoreContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("SpotcheckrCore"))
												  .EnableSensitiveDataLogging(_sensitiveDataLoggingEnabled));

		private static void ConfigureApplicationInsights() => _services.AddApplicationInsightsTelemetry();

		private static void ConfigureGraphQL() =>
			_services.AddGraphQLServer()
					 .AddApolloTracing(tracingPreference: _apolloTracingEnabled ? TracingPreference.Always : TracingPreference.Never)
					 .AddQueryType(d => d.Name("Query"))
						.AddType<UserQueries>()
						.AddType<CertificateQueries>()
						.AddType<OrganizationQueries>()
						.AddType<ExercisePostQueries>()
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
					 .AddType<ExercisePostType>()
					 .AddEnumType<UserType>()
					 .EnableRelaySupport();
	}
}
