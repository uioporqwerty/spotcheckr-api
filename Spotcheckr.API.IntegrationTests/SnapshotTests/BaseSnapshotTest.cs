using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Services.User;
using Spotcheckr.API.Types.Contact;
using Spotcheckr.API.Types.Identity;
using Spotcheckr.API.Types.Users;
using Spotcheckr.Data;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public abstract class BaseSnapshotTest
	{
		protected async Task<IRequestExecutor> GetRequestExecutor()
		{
			var executor = await new ServiceCollection()
				.AddPooledDbContextFactory<SpotcheckrCoreContext>(
					options => options.UseInMemoryDatabase("Spotcheckr-Core")
						.EnableSensitiveDataLogging(true))
				.AddTransient<IUserService, UserService>()
				.AddGraphQLServer()
				.AddQueryType(d => d.Name("Query"))
				.AddType<UserQueries>()
				.AddType<PersonalTrainerType>()
				.AddType<AthleteType>()
				.AddType<ContactInformationType>()
				.AddType<IdentityInformationType>()
				.EnableRelaySupport()
				.BuildRequestExecutorAsync();

			using var scope = executor.Services.CreateScope();
			var services = scope.ServiceProvider;

			DatabaseInitializer.Initialize(services.GetRequiredService<SpotcheckrCoreContext>());

			return executor;
		}
	}
}
