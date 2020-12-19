using System;

namespace Spotcheckr.Domain
{
	/// <summary>
	/// A certification is issued by a fitness training provider to qualified recipients.
	/// </summary>
	public class Certification : IEntityTracking
	{
		/// <summary>
		/// Unique identifier for the certification.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Unique certification number issued by the organization.
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// Determines if the certification has been verified by the organization.
		/// </summary>
		public bool Verified { get; set; }

		/// <summary>
		/// Date the certification was verified by Spotcheckr.
		/// </summary>
		public DateTime? DateVerified { get; set; }

		/// <summary>
		/// Date the certification was achieved by the personal trainer.
		/// </summary>
		public DateTime DateAchieved { get; set; }

		public int CertificateId { get; set; }

		public Certificate Certificate { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
