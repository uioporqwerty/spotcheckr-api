using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Models;

namespace Spotcheckr.API.Services
{
	public class CertificationService : ICertificationService
	{
		private readonly IUnitOfWork UnitOfWork;

		private readonly IMapper Mapper;

		private readonly ICertificationValidator NASMValidator;

		private readonly IDictionary<string, ICertificationValidator> Validators;

		public CertificationService(IUnitOfWork unitOfWork,
									IMapper mapper,
									NASMCertificationValidator nasmValidator)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
			NASMValidator = nasmValidator;
			Validators = new Dictionary<string, ICertificationValidator>
			{
				{ "NASM", NASMValidator }
			};
		}

		public async Task<Certification> CreateCertificationAsync(int userId,
																  int certificateId,
																  string certificationNumber,
																  DateTime? dateAchieved)
		{
			var newCertification = new Domain.Certification
			{
				UserId = userId,
				CertificateId = certificateId,
				DateAchieved = dateAchieved,
				Number = certificationNumber
			};
			UnitOfWork.Certifications.Add(newCertification);
			UnitOfWork.Complete();
			return Mapper.Map<Certification>(newCertification);
		}

		public async Task<bool> ValidateCertificationAsync(int certificationId)
		{
			var certificationDetails = await UnitOfWork.Certifications.GetCertificationDetails(certificationId);
			if (!certificationDetails.Verified)
			{
				var validator = Validators[certificationDetails.Certificate.Organization.Abbreviation];
				var certificateNumber = certificationDetails.Number;

				var searchCriteria = new CertificationValidationSearchCriteria(certificateNumber);

				var validationResults = await validator.ValidateAsync(searchCriteria);

				if (validationResults.Any())
				{
					certificationDetails.Verified = true;
					certificationDetails.DateVerified = SpotcheckrTimeUtilities.CurrentTime;
					UnitOfWork.Complete();
				}
			}

			return certificationDetails.Verified;
		}
	}
}
