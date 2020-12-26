using System.Collections.Generic;
using System.Threading.Tasks;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public interface ICertificateService
	{
		public Task<IEnumerable<Certificate>> GetCertificatesAsync();

		public Task<Certificate> GetCertificateAsync(int id);
	}
}
