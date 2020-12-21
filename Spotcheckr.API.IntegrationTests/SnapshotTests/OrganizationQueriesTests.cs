using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public class OrganizationQueriesTests : BaseSnapshotTest
	{
		private readonly IUnitOfWork UnitOfWork;

		public OrganizationQueriesTests()
		{
			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
		}

		[Fact]
		public async void GetOrganizations_WithGet_ReturnsOrganizations()
		{
			var organizations = new List<Organization>
			{
				new Organization("CPT", "Some Name"),
				new Organization("CPP", "Some other name")
			};
			UnitOfWork.Organizations.AddRange(organizations);
			UnitOfWork.Complete();

			var executor = await GetRequestExecutorAsync();
			var result = await executor.ExecuteAsync(@"
				query {
					organizations {
						abbreviation
						name
					}
				}
			");
			result.ToJson().MatchSnapshot();
		}
	}
}
