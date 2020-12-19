using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;

namespace Spotcheckr.API.IntegrationTests
{
	public abstract class BaseTest
	{
		private ServiceProvider ServiceProvider { get; }
		protected IUnitOfWork UnitOfWork { get; }
		protected IMapper Mapper { get; }

		public BaseTest()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<IUserService, UserService>()
							 .AddTransient<ICertificationService, CertificationService>()
							 .AddTransient<IUnitOfWork, UnitOfWork>()
							 .AddSingleton<DbContext, SpotcheckrCoreContext>()
							 .AddAutoMapper(typeof(Startup).Assembly)
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .EnableSensitiveDataLogging());
			ServiceProvider = serviceCollection.BuildServiceProvider();

			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
			Mapper = ServiceProvider.GetRequiredService<IMapper>();

			DatabaseInitializer.Initialize(ServiceProvider.GetRequiredService<SpotcheckrCoreContext>());
		}
	}
}
