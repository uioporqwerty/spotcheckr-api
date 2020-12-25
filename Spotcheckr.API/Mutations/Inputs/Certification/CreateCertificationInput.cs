using System;
using HotChocolate.Types.Relay;

namespace Spotcheckr.API.Mutations.Input
{
	public record CreateCertificationInput([ID] int UserId,
										   [ID] int CertificateId,
										   string CertificationNumber,
										   DateTime? DateAchieved
										   );
}
