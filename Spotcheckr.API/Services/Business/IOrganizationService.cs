﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public interface IOrganizationService
	{
		public Task<IEnumerable<Organization>> GetOrganizationsAsync();

		public Task<Organization> GetOrganizationAsync(int id);
	}
}
