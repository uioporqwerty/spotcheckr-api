using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class CertificationMutations
	{
		private readonly IMapper Mapper;

		public CertificationMutations(IMapper mapper)
		{
			Mapper = mapper;
		}

		/// <summary>
		/// Validate existing certification against an issuing organization.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="certificationService"></param>
		/// <returns></returns>
		public async Task<ValidateCertificationPayload> ValidateCertification(ValidateCertificationInput input,
																			  [Service] ICertificationService certificationService)
		{
			var validationStatus = await certificationService.ValidateCertification(input.CertificationId);
			return new ValidateCertificationPayload(validationStatus);
		}
	}
}
