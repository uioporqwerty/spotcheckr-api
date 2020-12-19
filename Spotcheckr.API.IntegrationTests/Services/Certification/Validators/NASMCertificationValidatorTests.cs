using System;
using System.Linq;
using Spotcheckr.API.Services.Validators;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.Services.Validators
{
	public class NASMCertificationValidatorTests
	{
		private readonly string TestCertificateId = "1190326987";
		private readonly ICertificationValidator NASMValidator;

		public NASMCertificationValidatorTests()
		{
			NASMValidator = new NASMCertificationValidator();
		}

		[Fact]
		public async void Validate_WithCertificateID_ReturnsValidValidationResponse()
		{
			var searchCriteria = new CertificationValidationSearchCriteria(TestCertificateId);
			var validationResponses = await NASMValidator.Validate(searchCriteria);

			Assert.Single(validationResponses);

			var response = validationResponses.First();
			Assert.Equal("Will Smith", response.FullName);
			Assert.Equal("1190326987", response.CertificationNumber);
			Assert.Equal(new DateTime(2021, 6, 1), response.ExpirationDate);
		}
	}
}
