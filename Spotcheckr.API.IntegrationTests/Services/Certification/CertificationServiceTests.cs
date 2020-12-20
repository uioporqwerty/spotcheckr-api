using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.Services
{
	public class CertificationServiceTests : BaseTest
	{
		private ICertificationService Service;
		private IUnitOfWork UnitOfWork;

		public CertificationServiceTests()
		{
			Service = ServiceProvider.GetRequiredService<ICertificationService>();
			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
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
			var org = new Organization
			{
				Abbreviation = "NASM"
			};
			UnitOfWork.Organizations.Add(org);
			var certificate = new Certificate { Code = "NASM-CPT", Organization = org };
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

			var actualResult = await Service.ValidateCertification(certification.Id);

			Assert.True(actualResult);
			Assert.True(certification.Verified);
		}
	}
}
