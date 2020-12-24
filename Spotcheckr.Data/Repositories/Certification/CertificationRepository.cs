using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class CertificationRepository : Repository<Certification>, ICertificationRepository
	{
		public CertificationRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;

		public async Task<Certification> GetCertificationDetails(int certificationId) => SpotcheckrCoreContext.Certifications.Where(cert => cert.Id == certificationId)
													   .Include(cert => cert.User)
													   .Include(cert => cert.Certificate)
													   .ThenInclude(cert => cert.Organization).First();
	}
}
