using System;
using HotChocolate.Types.Relay;

namespace Spotcheckr.API.Mutations.Input
{
	public record CreateCertificationInput([ID] int UserId,
										   [ID]
										   string CertificationNumber,
										   DateTime? DateAchieved
										   );
}
