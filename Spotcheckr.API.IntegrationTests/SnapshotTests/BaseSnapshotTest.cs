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
		protected async Task<IRequestExecutor> GetRequestExecutorAsync()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<IUserService, UserService>()
							 .AddTransient<IUnitOfWork, UnitOfWork>()
							 .AddTransient<IOrganizationService, OrganizationService>()
							 .AddTransient<ICertificateService, CertificateService>()
							 .AddTransient<IRestClient, RestClient>()
							 .AddSingleton<NASMCertificationValidator>()
							 .AddSingleton<DbContext, SpotcheckrCoreContext>()
							 .AddAutoMapper(typeof(Startup).Assembly)
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .EnableSensitiveDataLogging());


			var executor = await serviceCollection.AddGraphQLServer()
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
					 .AddType<CertificationType>()
					 .AddEnumType<UserType>()
					 .EnableRelaySupport()
					 .BuildRequestExecutorAsync();

			var serviceProvider = serviceCollection.BuildServiceProvider();
			var context = serviceProvider.GetRequiredService<DbContext>();
			context.Database.EnsureDeleted();
			DatabaseInitializer.Initialize(serviceProvider.GetRequiredService<SpotcheckrCoreContext>());

			return executor;
		}
	}
}
