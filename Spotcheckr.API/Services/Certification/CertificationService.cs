using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class CertificationService : ICertificationService
	{
		private readonly IMapper Mapper;

		private readonly IUnitOfWork UnitOfWork;

		private readonly IDictionary<string, ICertificationValidator> Validators = new Dictionary<string, ICertificationValidator>
		{
			{ "NASM", new NASMCertificationValidator() }
		};

		public CertificationService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
		}

		public async Task<bool> ValidateCertification(int certificationId)
		{
			var certificationDetails = await UnitOfWork.Certifications.GetCertificationDetails(certificationId);
			if (!certificationDetails.Verified)
			{
				var validator = Validators[certificationDetails.Certificate.Organization.Abbreviation];
				var certificateNumber = certificationDetails.Number;

				var searchCriteria = new CertificationValidationSearchCriteria(certificateNumber);

				var validationResults = await validator.Validate(searchCriteria);

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
