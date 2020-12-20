using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;
using Xunit;

namespace Spotcheckr.API.UnitTests.Services
{
	public class CertificateServiceTests : BaseTest
	{
		private readonly IUnitOfWork UnitOfWork;

		private readonly ICertificateService Service;

		public CertificateServiceTests()
		{
			UnitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
			Service = ServiceProvider.GetRequiredService<ICertificateService>();
		}

		[Fact]
		public async void GetCertificates_WithCertificates_ReturnsAllCertificates()
		{
			var certificates = GenerateCertificates();
			UnitOfWork.Certificates.AddRange(certificates);
			UnitOfWork.Complete();

			var result = await Service.GetCertificatesAsync();
			Assert.Equal(certificates.Count(), result.Count());
		}

		[Fact]
		public async void GetCertificatess_WithNoCertificates_ReturnsEmpty()
		{
			var result = await Service.GetCertificatesAsync();
			Assert.Empty(result);
		}

		[Fact]
		public async void GetCertificate_WithId_ReturnsCertificate()
		{
			var certificates = GenerateCertificates();
			UnitOfWork.Certificates.AddRange(certificates);
			UnitOfWork.Complete();
			var certificateId = certificates.First().Id;

			var result = await Service.GetCertificateAsync(certificateId);
			Assert.Equal(certificateId, result.Id);
		}

		[Fact]
		public async void GetCertificate_WithInvalidId_ThrowsException()
		{
			var certificates = GenerateCertificates();
			UnitOfWork.Certificates.AddRange(certificates);
			UnitOfWork.Complete();

			await Assert.ThrowsAsync<InvalidOperationException>(async () => await Service.GetCertificateAsync(-1));
		}

		private IEnumerable<Certificate> GenerateCertificates()
		{
			return new List<Certificate>
			{
				new Certificate(code: "NASM-CPT", description: "Certified Personal Trainer"),
				new Certificate(code: "NASM-CNC", description: "Nutrition Certification")
			};
		}
	}
}
