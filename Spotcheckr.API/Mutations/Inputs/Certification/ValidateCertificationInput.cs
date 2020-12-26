using HotChocolate.Types.Relay;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record ValidateCertificationInput([ID(nameof(Certification))] int CertificationId);
}
