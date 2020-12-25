using HotChocolate.Types.Relay;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record DeleteCertificationInput([ID] int certificationId);
}
