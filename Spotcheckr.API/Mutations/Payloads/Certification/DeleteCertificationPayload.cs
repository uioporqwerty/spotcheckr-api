using HotChocolate.Types.Relay;

namespace Spotcheckr.API.Mutations.Payloads
{
	public record DeleteCertificationPayload([ID] int certificationID);
}