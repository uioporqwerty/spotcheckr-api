using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using Spotcheckr.API.Services;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;

namespace Spotcheckr.API.UnitTests
{
	public class ServiceFixture
	{
		public ServiceProvider ServiceProvider { get; }

		public ServiceFixture()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddScoped<IUserService, UserService>()
							 .AddScoped<ICertificationService, CertificationService>()
							 .AddScoped<IOrganizationService, OrganizationService>()
							 .AddScoped<ICertificateService, CertificateService>()
							 .AddScoped<IUnitOfWork, UnitOfWork>()
							 .AddScoped<IUserRepository, UserRepository>()
							 .AddScoped<IExercisePostRepository, ExercisePostRepository>()
							 .AddScoped<IEmailRepository, EmailRepository>()
							 .AddScoped<IPhoneNumberRepository, PhoneNumberRepository>()
							 .AddScoped<ICertificationRepository, CertificationRepository>()
							 .AddScoped<ICertificateRepository, CertificateRepository>()
							 .AddScoped<IOrganizationRepository, OrganizationRepository>()
							 .AddTransient<IRestClient, RestClient>()
							 .AddSingleton<NASMCertificationValidator>()
							 .AddAutoMapper(typeof(Startup).Assembly)
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
																		 .EnableSensitiveDataLogging());
			ServiceProvider = serviceCollection.BuildServiceProvider();
		}
	}
}
