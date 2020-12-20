using HotChocolate.Types.Relay;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record ValidateCertificationInput([ID(nameof(Certification))] int CertificationId);
}
