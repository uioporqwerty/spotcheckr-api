using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class CertificateRepository : Repository<Certificate>, ICertificateRepository
	{
		public CertificateRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context as SpotcheckrCoreContext;
	}
}
