using System;
namespace Spotcheckr.API.Services.Validators
{
	public class CertificationValidationResponse
	{
		public string FullName { get; set; }

		public string CertificationNumber { get; set; }

		public DateTime? DateIssued { get; set; }

		public DateTime? ExpirationDate { get; set; }
	}
}
