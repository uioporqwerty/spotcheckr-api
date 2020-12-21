﻿using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.SnapshotTests
{
	public class CertificateQueriesTests : BaseSnapshotTest
	{
		private readonly IUnitOfWork UnitOfWork;

		public CertificateQueriesTests()
		{
			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
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
