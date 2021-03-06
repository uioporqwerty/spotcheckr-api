﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.Services.Validators
{
	public class NASMCertificationValidatorTests : BaseTest
	{
		private readonly string TestCertificateId = "1190326987";
		private readonly ICertificationValidator NASMValidator;

		public NASMCertificationValidatorTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			NASMValidator = ServiceProvider.GetRequiredService<NASMCertificationValidator>();
		}

		[Fact]
		public async void Validate_WithCertificateID_ReturnsValidValidationResponse()
		{
			var searchCriteria = new CertificationValidationSearchCriteria(TestCertificateId);
			var validationResponses = await NASMValidator.ValidateAsync(searchCriteria);

			Assert.Single(validationResponses);

			var response = validationResponses.First();
			Assert.Equal("Will Smith", response.FullName);
			Assert.Equal("1190326987", response.CertificationNumber);
			Assert.Equal(new DateTime(2021, 6, 1), response.ExpirationDate);
		}
	}
}
