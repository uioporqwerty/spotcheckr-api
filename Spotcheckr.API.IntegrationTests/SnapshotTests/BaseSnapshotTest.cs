using System;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using Spotcheckr.API.Mutations;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.API.Types;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public abstract class BaseSnapshotTest
	{
		protected IServiceProvider ServiceProvider { get; }

		private readonly IServiceCollection ServiceCollection;

		public BaseSnapshotTest()
		{
			ServiceCollection = new ServiceCollection();
			ServiceCollection.AddTransient<IUserService, UserService>()
							 .AddTransient<IUnitOfWork, UnitOfWork>()
							 .AddTransient<IOrganizationService, OrganizationService>()
							 .AddTransient<ICertificateService, CertificateService>()
							 .AddTransient<IRestClient, RestClient>()
							 .AddSingleton<NASMCertificationValidator>()
							 .AddTransient<DbContext, SpotcheckrCoreContext>()
							 .AddAutoMapper(typeof(Startup).Assembly)
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .EnableSensitiveDataLogging());

			ServiceProvider = ServiceCollection.BuildServiceProvider();

			var context = ServiceProvider.GetRequiredService<DbContext>();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		protected async Task<IRequestExecutor> GetRequestExecutorAsync()
		{
			var executor = await ServiceCollection.AddGraphQLServer()
					 .AddQueryType(d => d.Name("Query"))
						.AddType<UserQueries>()
						.AddType<CertificateQueries>()
						.AddType<OrganizationQueries>()
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
					 .AddType<CertificationType>()
					 .AddType<OrganizationType>()
					 .AddEnumType<UserType>()
					 .EnableRelaySupport()
					 .BuildRequestExecutorAsync();

			return executor;
		}
	}
}
