﻿using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public interface ICertificationRepository : IRepository<Certification>
	{
		public Task<Certification> GetCertificationDetails(int certificationId);
	}
}
