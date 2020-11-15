using System;

namespace Spotcheckr.API.Data
{
	public class Certification
	{
		public Certificate Certificate { get; set; }

		public int CertificateId { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }

		public DateTime DateAchieved { get; set; }
	}
}
