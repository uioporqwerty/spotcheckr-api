using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
	{
		public OrganizationRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;
	}
}
