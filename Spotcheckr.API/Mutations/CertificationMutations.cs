using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Input;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class CertificationMutations
	{
		/// <summary>
		/// Validate existing certification against an issuing organization.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="certificationService"></param>
		/// <returns></returns>
		public async Task<ValidateCertificationPayload> ValidateCertificationAsync(ValidateCertificationInput input,
																				   [Service] ICertificationService certificationService)
		{
			var validationStatus = await certificationService.ValidateCertification(input.CertificationId);
			return new ValidateCertificationPayload(validationStatus);
		}

		/// <summary>
		/// Create a new certification and apply it towards a user. Once created, you may also want to validate the certification
		/// using the ValidateCertification mutation.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="certificationService"></param>
		/// <returns></returns>
		public async Task<CreateCertificationPayload> CreateCertificationAsync(CreateCertificationInput input,
																			   [Service] ICertificationService certificationService)
		{
			return new CreateCertificationPayload(new Certification());
		}
	}
}
