using Spotcheckr.API.Tests.Common.Fixtures;
using Xunit;

namespace Spotcheckr.API.UnitTests
{
	[CollectionDefinition("Service collection")]
	public class ServiceCollection : ICollectionFixture<ServiceFixture>
	{
	}
}
