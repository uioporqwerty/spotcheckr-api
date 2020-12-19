using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Mutations;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services;
using Spotcheckr.API.Types;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public abstract class BaseSnapshotTest
	{
		protected async Task<IRequestExecutor> GetRequestExecutor()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<IUserService, UserService>()
							 .AddTransient<IUnitOfWork, UnitOfWork>()
							 .AddSingleton<DbContext, SpotcheckrCoreContext>()
							 .AddDbContext<SpotcheckrCoreContext>(options =>
																  options.UseInMemoryDatabase("Spotcheckr-Core")
																		 .EnableSensitiveDataLogging());


			var executor = await serviceCollection.AddGraphQLServer()
					 .AddQueryType(d => d.Name("Query"))
						.AddType<UserQueries>()
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
			DatabaseInitializer.Initialize(serviceProvider.GetRequiredService<SpotcheckrCoreContext>());

			return executor;
		}
	}
}
