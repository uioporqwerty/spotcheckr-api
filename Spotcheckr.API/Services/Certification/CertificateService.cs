using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Models;

namespace Spotcheckr.API.Services
{
	public class CertificateService : ICertificateService
	{
		private readonly IUnitOfWork UnitOfWork;

		private readonly IMapper Mapper;

		public CertificateService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
		}

		public async Task<Certificate> GetCertificateAsync(int id)
		{
			var certificate = await UnitOfWork.Certificates.GetAsync(id);
			return Mapper.Map<Certificate>(certificate);
		}

		public async Task<IEnumerable<Certificate>> GetCertificatesAsync()
		{
			var certificates = new List<Certificate>();
			var allExistingCertificates = await UnitOfWork.Certificates.GetAllAsync();
			certificates.AddRange(Mapper.Map<IEnumerable<Certificate>>(allExistingCertificates));
			return certificates;
		}
	}
}