using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.API.Domain;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.Services
{
	public class CertificationServiceTests : BaseTest
	{
		private ICertificationService Service;

		public CertificationServiceTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			Service = ServiceProvider.GetRequiredService<ICertificationService>();
		}

		[Fact]
		public async void ValidateCertification_WithCertification_ReturnsStatus()
		{
			var user = new User
			{
				FirstName = "Will",
				LastName = "Smith",
			};
			UnitOfWork.Users.Add(user);
			var org = new Organization("NASM", "National Academy of Sport Medicine");
			UnitOfWork.Organizations.Add(org);
			var certificate = new Certificate(code: "NASM-CPT", description: "Certified Personal Trainer")
			{
				Organization = org
			};
			UnitOfWork.Certificates.Add(certificate);
			var certification = new Certification
			{
				Number = "1190326987",
				Verified = false,
				User = user,
				Certificate = certificate
			};
			UnitOfWork.Certifications.Add(certification);
			UnitOfWork.Complete();

			var actualResult = await Service.ValidateCertificationAsync(certification.Id);

			Assert.True(actualResult);
			Assert.True(certification.Verified);
		}
	}
}
