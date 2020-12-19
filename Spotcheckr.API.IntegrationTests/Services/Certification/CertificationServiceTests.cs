using Spotcheckr.API.Services;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.IntegrationTests.Services
{
	public class CertificationServiceTests : BaseTest
	{
		[Fact]
		public async void ValidateCertification_WithCertification_ReturnsStatus()
		{
			var service = CreateCertificationService();
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

			var actualResult = await service.ValidateCertification(certification.Id);

			Assert.True(actualResult);
			Assert.True(certification.Verified);
		}

		private ICertificationService CreateCertificationService() => new CertificationService(UnitOfWork, Mapper);
	}
}
