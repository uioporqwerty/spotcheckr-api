using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Spotcheckr.API.Tests.Common.Fixtures;
using Xunit;

namespace Spotcheckr.API.SnapshotTests
{
	public class UserMutationTests : BaseSnapshotTest
	{
		public UserMutationTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
		}

		[Fact]
		public async void CreateUser_WithPost_ReturnsNewUser()
		{
			var executor = await GetRequestExecutorAsync();
			var newUser = await executor.ExecuteAsync(@"
				mutation {
					createUser(input: { userType: ATHLETE }) {
						user {
							id
						}
					}
				}
			");
			newUser.ToJson().MatchSnapshot();
		}
	}
}
