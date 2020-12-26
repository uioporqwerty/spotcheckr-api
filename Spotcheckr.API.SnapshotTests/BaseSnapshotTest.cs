using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Mutations;
using Spotcheckr.API.Queries;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.API.Types;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.SnapshotTests
{
	public abstract class BaseSnapshotTest : BaseTest
	{
		private readonly IServiceCollection ServiceCollection;

		public BaseSnapshotTest(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			ServiceCollection = serviceFixture.ServiceCollection;
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
