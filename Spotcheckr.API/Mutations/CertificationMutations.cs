using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Input;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

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
			var validationStatus = await certificationService.ValidateCertificationAsync(input.CertificationId);
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
			var newCertification = await certificationService.CreateCertificationAsync(input.UserId, input.CertificateId, input.CertificationNumber, input.DateAchieved);
			return new CreateCertificationPayload(newCertification);
		}

		/// <summary>
		/// Delete a certification that is applied towards a user.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="certificationService"></param>
		/// <returns></returns>
		public async Task<DeleteCertificationPayload> DeleteCertificationAsync(DeleteCertificationInput input,
																			   [Service] ICertificationService certificationService)
		{
			await certificationService.DeleteCertificationAsync(input.certificationId);
			return new DeleteCertificationPayload(input.certificationId);
		}

		/// <summary>
		/// Update an existing certification applied towards a user.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="certificationService"></param>
		/// <returns></returns>
		public async Task<UpdateCertificationPayload> UpdateCertificationAsync(UpdateCertificationInput input,
																			  [Service] ICertificationService certificationService)
		{
			var updatedCertification = await certificationService.UpdateCertificationAsync(input.CertificationId,
																						   input.CertificateId,
																						   input.CertificationNumber,
																						   input.DateAchieved);
			return new UpdateCertificationPayload(updatedCertification);
		}
	}
}
