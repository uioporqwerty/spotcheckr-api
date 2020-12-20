using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotcheckr.API.Services.Validators;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class CertificationService : ICertificationService
	{
		private readonly IUnitOfWork UnitOfWork;

		private readonly ICertificationValidator NASMValidator;

		private readonly IDictionary<string, ICertificationValidator> Validators;

		public CertificationService(IUnitOfWork unitOfWork,
									NASMCertificationValidator nasmValidator)
		{
			UnitOfWork = unitOfWork;
			NASMValidator = nasmValidator;
			Validators = new Dictionary<string, ICertificationValidator>
			{
				{ "NASM", NASMValidator }
			};
		}

		public async Task<bool> ValidateCertification(int certificationId)
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
