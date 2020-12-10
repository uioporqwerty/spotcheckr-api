using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
    public class UserSnapshotTests : BaseSnapshotTest
    {
	    [Fact]
	    public async Task GetAthlete_WithId_ReturnsAthlete()
	    {
		    var executor = await GetRequestExecutor();

		    var result = await executor.ExecuteAsync(new QueryRequest(new QuerySourceText(@"
query {
	athlete(id: 1) {
		id
	}
}
													")));
		    Snapshot.Match(result.ToJson());
	    }
    }
}
