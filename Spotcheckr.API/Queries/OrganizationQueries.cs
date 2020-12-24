using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class OrganizationQueries
	{
		/// <summary>
		/// Retrieve all available organizations that issue certificates..
		/// </summary>
		/// <param name="organizationService"></param>
		/// <returns></returns>
		public async Task<IEnumerable<Organization>> GetOrganizationsAsync([Service] IOrganizationService organizationService) => await organizationService.GetOrganizationsAsync();
	}
}
