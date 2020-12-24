using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Models;

namespace Spotcheckr.API.Services
{
	public class OrganizationService : IOrganizationService
	{
		private readonly IUnitOfWork UnitOfWork;

		private readonly IMapper Mapper;

		public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
		}

		public async Task<Organization> GetOrganizationAsync(int id)
		{
			var organization = await UnitOfWork.Organizations.GetAsync(id);
			return Mapper.Map<Organization>(organization);
		}

		public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
		{
			var organizations = new List<Organization>();
			var allExistingOrganizations = await UnitOfWork.Organizations.GetAllAsync();
			organizations.AddRange(Mapper.Map<IEnumerable<Organization>>(allExistingOrganizations));
			return organizations;
		}
	}
}