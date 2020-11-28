using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	[Table("Certifications")]
	public class Certification : IEntityTracking
	{
		public int Id { get; set; }

		public string Number { get; set; }

		[DefaultValue(false)]
		public bool Verified { get; set; }

		public DateTime? DateVerified { get; set; }

		public DateTime DateAchieved { get; set; }

		public int CertificateId { get; set; }

		public Certificate Certificate { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
