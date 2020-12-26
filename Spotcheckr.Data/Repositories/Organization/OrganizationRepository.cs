using Spotcheckr.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
	{
		public OrganizationRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;
	}
}
