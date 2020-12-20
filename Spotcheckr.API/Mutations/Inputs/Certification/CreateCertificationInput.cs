using System;
using HotChocolate.Types.Relay;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations.Input
{
	public record CreateCertificationInput([ID] int UserId,
										   [ID]
										   string CertificationNumber,
										   DateTime? DateAchieved
										   );
}
