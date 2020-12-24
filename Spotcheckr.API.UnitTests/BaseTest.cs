using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestSharp;
using Spotcheckr.API.Services;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Xunit.Abstractions;

namespace Spotcheckr.API.UnitTests
{
	public abstract class BaseTest
	{
		protected ServiceProvider ServiceProvider { get; }

		protected IUnitOfWork UnitOfWork { get; }

		public BaseTest()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<IUserService, UserService>()
							 .AddTransient<ICertificationService, CertificationService>()
							 .AddTransient<IOrganizationService, OrganizationService>()
							 .AddTransient<ICertificateService, CertificateService>()
							 .AddScoped<IUnitOfWork, UnitOfWork>()
							 .AddTransient<IRestClient, RestClient>()
							 .AddSingleton<NASMCertificationValidator>()
							 .AddAutoMapper(typeof(Startup).Assembly)
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .EnableSensitiveDataLogging());
			ServiceProvider = serviceCollection.BuildServiceProvider();
			var context = ServiceProvider.GetRequiredService<SpotcheckrCoreContext>();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
		}
	}
}
