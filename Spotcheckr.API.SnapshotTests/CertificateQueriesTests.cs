using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.SnapshotTests
{
	public class CertificateQueriesTests : BaseSnapshotTest
	{
		public CertificateQueriesTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
		}

		[Fact]
		public async void GetCertificates_WithGet_ReturnsCertificates()
		{
			var certificates = new List<Certificate>
			{
				new Certificate("NASM-CPT", "Some cert description"),
				new Certificate("NASM-CPP", "Some other cert description")
			};
			UnitOfWork.Certificates.AddRange(certificates);
			UnitOfWork.Complete();
			var executor = await GetRequestExecutorAsync();
			var result = await executor.ExecuteAsync(@"
				query {
					certificates() {
						code
						description
					}
				}
			");

			result.ToJson().MatchSnapshot();
		}
	}
}
