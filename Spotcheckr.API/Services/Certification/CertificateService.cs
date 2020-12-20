using System.Collections.Generic;
using System.Threading.Tasks;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class CertificateService : ICertificateService
	{
		private readonly IUnitOfWork UnitOfWork;

		public CertificateService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task<Certificate> GetCertificateAsync(int id)
		{
			var certificate = await UnitOfWork.Certificates.GetAsync(id);
			return certificate;
		}

		public async Task<IEnumerable<Certificate>> GetCertificatesAsync()
		{
			var certificates = new List<Certificate>();
			certificates.AddRange(await UnitOfWork.Certificates.GetAllAsync());
			return certificates;
		}
	}
}