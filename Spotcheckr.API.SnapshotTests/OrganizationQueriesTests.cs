using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.API.Domain;
using Xunit;

namespace Spotcheckr.API.SnapshotTests
{
	public class OrganizationQueriesTests : BaseSnapshotTest
	{
		public OrganizationQueriesTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
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
