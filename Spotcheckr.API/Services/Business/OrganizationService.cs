using System.Collections.Generic;
using System.Threading.Tasks;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class OrganizationService : IOrganizationService
	{
		private readonly IUnitOfWork UnitOfWork;

		public OrganizationService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task<Organization> GetOrganizationAsync(int id)
		{
			var organization = await UnitOfWork.Organizations.GetAsync(id);
			return organization;
		}

		public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
		{
			var organizations = new List<Organization>();
			organizations.AddRange(await UnitOfWork.Organizations.GetAllAsync());
			return organizations;
		}
	}
}