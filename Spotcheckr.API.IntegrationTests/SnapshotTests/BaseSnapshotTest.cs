using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services;
using Spotcheckr.API.Types.Users;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;

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
					 .AddType<PersonalTrainerType>()
					 .AddType<AthleteType>()
					 .EnableRelaySupport()
					 .BuildRequestExecutorAsync();

			var serviceProvider = serviceCollection.BuildServiceProvider();
			DatabaseInitializer.Initialize(serviceProvider.GetRequiredService<SpotcheckrCoreContext>());

			return executor;
		}
	}
}
