using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.UnitTests.Services
{
	public class OrganizationServiceTests : BaseTest
	{
		private readonly IOrganizationService Service;

		public OrganizationServiceTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			Service = ServiceProvider.GetRequiredService<IOrganizationService>();
		}

		[Fact]
		public async void GetOrganizations_WithOrganizations_ReturnsAllOrganizations()
		{
			var organizations = GenerateOrganizations();
			UnitOfWork.Organizations.AddRange(organizations);
			UnitOfWork.Complete();

			var result = await Service.GetOrganizationsAsync();
			Assert.Equal(organizations.Count(), result.Count());
		}

		[Fact]
		public async void GetOrganizations_WithNoOrganizations_ReturnsEmpty()
		{
			var result = await Service.GetOrganizationsAsync();
			Assert.Empty(result);
		}

		[Fact]
		public async void GetOrganization_WithId_ReturnsOrganization()
		{
			var organizations = GenerateOrganizations();
			UnitOfWork.Organizations.AddRange(organizations);
			UnitOfWork.Complete();
			var organizationId = organizations.First().Id;

			var result = await Service.GetOrganizationAsync(organizationId);
			Assert.Equal(organizationId, result.Id);
		}

		[Fact]
		public async void GetOrganization_WithInvalidId_ThrowsException()
		{
			await Assert.ThrowsAsync<InvalidOperationException>(async () => await Service.GetOrganizationAsync(-1));
		}

		private IEnumerable<Organization> GenerateOrganizations()
		{
			return new List<Organization>
			{
				new Organization("TEST", "Test Organization"),
				new Organization("TEST2", "Test Organzation 2")
			};
		}
	}
}
