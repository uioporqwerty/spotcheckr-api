using HotChocolate.Execution;
using Snapshooter.Xunit;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public class CertificateQueriesTests : BaseSnapshotTest
	{
		[Fact]
		public async void GetCertificates_WithGet_ReturnsCertificates()
		{
			var executor = await GetRequestExecutorAsync();
			var result = await executor.ExecuteAsync(@"
				query {
					certificates() {
						id
						code
						description
					}
				}
			");

			result.MatchSnapshot();
		}
	}
}
