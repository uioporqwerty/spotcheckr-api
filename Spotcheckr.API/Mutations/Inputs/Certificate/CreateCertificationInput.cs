using System;
using HotChocolate.Types.Relay;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations.Input
{
	public record CreateCertificationInput([ID] int UserId,
										   [ID(nameof(Organization))] int OrganizationId,
										   string CertificationNumber,
										   DateTime? DateAchieved
										   );
}
