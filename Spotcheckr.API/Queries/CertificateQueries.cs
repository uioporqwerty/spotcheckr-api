using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class CertificateQueries
	{
		/// <summary>
		/// Retrieve available certificates for user to apply for.
		/// </summary>
		/// <param name="certificateService"></param>
		/// <returns></returns>
		public async Task<IEnumerable<Certificate>> GetCertificatesAsync([Service] ICertificateService certificateService) => await certificateService.GetCertificatesAsync();
	}
}
