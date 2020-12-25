using System;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Xunit;

namespace Spotcheckr.API.UnitTests.Services
{
	public class CertificationServiceTests : BaseTest
	{
		private readonly ICertificationService Service;

		public CertificationServiceTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			Service = serviceFixture.ServiceProvider.GetRequiredService<ICertificationService>();
		}

		[Fact]
		public async void CreateCertification_ForUser_ReturnsNewCertification()
		{
			var user = GetPersonalTrainer;
			var certificate = GetCertificate;
			UnitOfWork.Users.Add(user);
			UnitOfWork.Certificates.Add(certificate);
			UnitOfWork.Complete();
			var certificationNumber = "12345";
			var newCertification = await Service.CreateCertificationAsync(user.Id, certificate.Id, certificationNumber, dateAchieved: new DateTime(1990, 3, 17));
			Assert.Equal(newCertification.Number, certificationNumber);
		}

		[Fact]
		public async void DeleteCertification_ForUser_RemovesCertification()
		{
			var user = GetPersonalTrainer;
			var certificate = GetCertificate;
			UnitOfWork.Users.Add(user);
			UnitOfWork.Certificates.Add(certificate);
			var certification = new Domain.Certification
			{
				UserId = user.Id,
				CertificateId = certificate.Id
			};
			UnitOfWork.Certifications.Add(certification);
			UnitOfWork.Complete();
			await Service.DeleteCertificationAsync(certification.Id);
			await Assert.ThrowsAsync<InvalidOperationException>(async () => await UnitOfWork.Certifications.GetAsync(certification.Id));
		}

		private Domain.User GetPersonalTrainer => new Domain.User
		{
			Type = Domain.UserType.PersonalTrainer
		};

		private Domain.Certificate GetCertificate => new Domain.Certificate(code: "NASM-CPT", description: "CPT Certificate");
	}
}
