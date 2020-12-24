using HotChocolate.Types.Relay;
using Spotcheckr.Models;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record ValidateCertificationInput([ID(nameof(Certification))] int CertificationId);
}
