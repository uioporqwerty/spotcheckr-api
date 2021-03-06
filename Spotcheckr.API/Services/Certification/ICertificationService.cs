﻿using System;
using System.Threading.Tasks;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public interface ICertificationService
	{
		public Task<bool> ValidateCertificationAsync(int certificationId);

		public Task<Certification> CreateCertificationAsync(int userId,
															int certificateId,
															string certificationNumber,
															DateTime? dateAchieved);

		public Task<int> DeleteCertificationAsync(int certificateId);

		public Task<Certification> UpdateCertificationAsync(int certificationId,
															int certificateId,
															string certificationNumber,
															DateTime? dateAchieved);
	}
}
