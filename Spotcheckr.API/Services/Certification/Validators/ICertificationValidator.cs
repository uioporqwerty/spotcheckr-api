using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotcheckr.API.Services.Validators
{
	public interface ICertificationValidator
	{
		public Task<IEnumerable<CertificationValidationResponse>> Validate(CertificationValidationSearchCriteria searchCriteria);
	}
}
