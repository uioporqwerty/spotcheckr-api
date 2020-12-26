using System;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record UpdateCertificationInput([ID(nameof(Certification))] int CertificationId,
										   [ID(nameof(Certificate))] int CertificateId,
										   string CertificationNumber,
										   DateTime? DateAchieved);
}
