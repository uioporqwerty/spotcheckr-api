using System;

namespace Spotcheckr.API.Models
{
	/// <summary>
	/// A certification is issued by a fitness training provider to qualified recipients.
	/// </summary>
	public class Certification
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

		public Certificate Certificate { get; set; }
	}
}
